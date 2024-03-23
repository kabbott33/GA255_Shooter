using JetBrains.Annotations;
using Palmmedia.ReportGenerator.Core.CodeAnalysis;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public AudioSource fire;
    public int maxRange = 1000;
    public int damage = 50;
    public float fireRate = 0.01f;
    public float nextFire = 0.0f;
    public GameObject bulletHole;

    //ADS positions
    public GameObject gun;
    public Transform hipFireTransform;
    public Transform adsTransform;
    public float speed;

    //Accuracy
    public float size;
    public float minInaccuracy;
    public float midInaccuracy;
    public float maxInaccuracy;
    private float currentAccuracy;
    public bool isAiming;
    // Start is called before the first frame update
    void Start()
    {
        fire = this.GetComponent<AudioSource>();
        if (fire == null) fire = gameObject.AddComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        ADS();
        Accuracy();
    }

    private void Accuracy()
    {
        if (isAiming)
        {
            currentAccuracy = Mathf.Lerp(currentAccuracy, minInaccuracy, Time.deltaTime * speed);
        }
        else if ((isMoving)&&!(isAiming))
        {
            currentAccuracy = Mathf.Lerp(currentAccuracy, maxInaccuracy, Time.deltaTime * speed);
        }
        else
        {
            currentAccuracy = Mathf.Lerp(currentAccuracy, midInaccuracy, Time.deltaTime * speed);
        }
    }
    private void ADS()
    {
        if ((Input.GetKey(KeyCode.Mouse1)))
        {
            gun.transform.position = Vector3.Lerp(gun.transform.position, adsTransform.position, speed*Time.deltaTime);
            isAiming = true;
        }
        else
        {
            gun.transform.position = Vector3.Lerp(gun.transform.position, hipFireTransform.position, speed*Time.deltaTime);
            isAiming = false;
        }

    }
    private void Shoot()
    {
            if ((Input.GetKeyDown(KeyCode.Mouse0)) && Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            fire.Play();
            Vector3 aim = this.transform.forward;
            aim = Quaternion.AngleAxis(Random.Range(0, currentAccuracy), UnityEngine.Vector3.up) * aim;
            aim = Quaternion.AngleAxis(Random.Range(0, 360), this.transform.forward) * aim;
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, aim, out hit, maxRange))
            {
                //        if ((hit.collider.CompareTag("Head")) || hit.collider.CompareTag("Body"))

                //        {
                if (hit.collider.CompareTag("Head"))
                {
                    hit.transform.parent.GetComponent<EnemyHealth>().Headshot(damage);
                    Debug.Log("head");
                }
                else if (hit.collider.CompareTag("Body"))
                {
                    hit.transform.parent.GetComponent<EnemyHealth>().Bodyshot(damage);
                    Debug.Log("body");
                }
                else
                {
                    GameObject bH = Instantiate(bulletHole, hit.point, Quaternion.LookRotation(hit.normal));
                    bH.transform.position += bH.transform.forward / 1000;
                }
                //GameObject bH= Instantiate(bulletHole, hit.point + new Vector3(hit.normal.x * 0.01f, hit.normal.y * 0.01f, hit.normal.z * 0.01f), Quaternion.LookRotation(hit.normal));

                //        }
            }
        }
       
    }
    bool isMoving
    {
        get
        {
            if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)))
                return true;
            else
                return false;


        }
    }
}
