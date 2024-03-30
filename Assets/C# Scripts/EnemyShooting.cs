using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
