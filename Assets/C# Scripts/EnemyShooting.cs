using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.Rendering;
using System.Drawing;
using Unity.VisualScripting;
using Color = UnityEngine.Color;

public class EnemyShooting : MonoBehaviour
{
    private GameObject player;
    public AudioSource fire;


    public int maxRange = 1000;
    public int damage = 50;
    public float fireRate = 0.5f;
    public float nextFire = 0.0f;
    public float accuracy;
    public GameObject firepoint;
    public float tracerDuration = 0.2f;

    public Material particleMaterial;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fire = this.GetComponent<AudioSource>();
        if (fire == null) fire = gameObject.AddComponent<AudioSource>();
        //firepoint = this.transform.GetComponent
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot()
    {
        this.transform.LookAt(player.transform.position);
        if (Time.time > nextFire)
        {

            nextFire = Time.time + fireRate;
            fire.Play();
            Vector3 aim = player.transform.position - this.transform.position;
            aim = Quaternion.AngleAxis(Random.Range(0, accuracy), UnityEngine.Vector3.up) * aim;
            aim = Quaternion.AngleAxis(Random.Range(0, 360), this.transform.forward) * aim;
            RaycastHit hit;
            DrawLine(firepoint.transform.position, aim, Color.white, maxRange, tracerDuration);
            if (Physics.Raycast(this.transform.position, aim, out hit, maxRange))
            {
                //        if ((hit.collider.CompareTag("Head")) || hit.collider.CompareTag("Body"))

                //        {
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("PLAYERHIT");
                    player.GetComponent<PHealth>().Hit(damage);
                    //hit.transform.GetComponent<PHealth>().Hit(damage);

                }
            }
        }
    }
    void DrawLine(Vector3 start, Vector3 direction, Color color, float maxDistance, float duration = 0.2f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;

        Vector3 end = start + direction.normalized * maxDistance;

        LineRenderer lr = myLine.AddComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Standard"));
        lr.startColor = color;
        lr.endColor = color;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);

        GameObject.Destroy(myLine, duration);
    }
}
