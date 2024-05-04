using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.Rendering;
using System.Drawing;
using Unity.VisualScripting;
using Color = UnityEngine.Color;

public class Turret : MonoBehaviour
{
    private GameObject player;
    public AudioSource fire;


    public int maxRange = 1000;
    public int damage = 50;
    public float fireRate = 0.5f;
    public float nextFire = 0.0f;
    public float accuracy;
    public Transform firepoint;
    public float tracerDuration = 0.2f;

    public GameObject gun;



    public float aggroDistance;
    public bool isAggroed;

    private float flightDistance;


    public List<Transform> firepoints;

    private int firepointIndex = 0;

    public Material particleMaterial;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("FirstPersonController");
        fire = this.GetComponent<AudioSource>();
        if (fire == null) fire = gameObject.AddComponent<AudioSource>();
        //firepoint = this.transform.GetComponent

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) < aggroDistance)
        {
            isAggroed = true;
        }

        if (isAggroed) 
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        gun.transform.LookAt(player.transform.position);
        if (Time.time > nextFire)
        {

            nextFire = Time.time + fireRate;
            AlternateFirepoint();
            firepoint.LookAt(player.transform.position);
            fire.Play();
            Vector3 aim = player.transform.position - firepoint.transform.position;
            aim = Quaternion.AngleAxis(Random.Range(0, accuracy), UnityEngine.Vector3.up) * aim;
            aim = Quaternion.AngleAxis(Random.Range(0, 360), firepoint.transform.forward) * aim;
            RaycastHit hit;
            
            if (Physics.Raycast(firepoint.transform.position, aim, out hit, maxRange))
            {
                //        if ((hit.collider.CompareTag("Head")) || hit.collider.CompareTag("Body"))
                Debug.Log(hit.collider.name);
                flightDistance = hit.distance;
                
                //        {
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("PLAYERHIT");
                    player.GetComponent<PHealth>().Hit(damage);
                    //hit.transform.GetComponent<PHealth>().Hit(damage);

                }
                DrawLine(firepoint.transform.position, aim, Color.white, flightDistance, tracerDuration);
            }
        }
    }
    void DrawLine(Vector3 start, Vector3 direction, Color color, float flightDistance, float duration = 0.2f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;

        Vector3 end = start + direction.normalized * flightDistance;

        LineRenderer lr = myLine.AddComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Standard"));
        lr.startColor = color;
        lr.endColor = color;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);

        Debug.Log(flightDistance);
        GameObject.Destroy(myLine, duration);

    }

    public void AlternateFirepoint()
    {
        firepointIndex++;
        if (firepointIndex >= firepoints.Count)
        {
            firepointIndex = 0;
        }

        firepoint = firepoints[firepointIndex];
    }
}
