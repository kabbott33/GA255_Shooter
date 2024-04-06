using JetBrains.Annotations;
using Palmmedia.ReportGenerator.Core.CodeAnalysis;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public AudioSource fire;
    public AudioSource reloadingSound; // Reference to the reloading sound

    public int maxRange = 1000;
    public int damage = 50;
    public float fireRate = 0.01f;
    public float nextFire = 0.0f;
    public GameObject bulletHole;
    public TextMeshProUGUI ammoText;
    public Slider reloadSlider;
    public float reloadTime = 3.0f;
    private int remainingBullets = 6;
    private float reloadTimer = 0.0f;
    public bool isReloading = false;

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

    void Start()
    {
        fire = this.GetComponent<AudioSource>();
        if (fire == null) fire = gameObject.AddComponent<AudioSource>();

        UpdateAmmoUI();
        reloadingSound.loop = true; // Set the reloading sound to loop
        reloadingSound.Stop(); // Stop the sound initially
    }

    void Update()
    {
        if (isReloading)
        {
            PerformReload();
        }


            Shoot();
            ADS();
            Accuracy();
            Reload();

    }

    private void Accuracy()
    {
        if (isAiming)
        {
            currentAccuracy = Mathf.Lerp(currentAccuracy, minInaccuracy, Time.deltaTime * speed);
        }
        else if ((isMoving) && !(isAiming))
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
            gun.transform.position = Vector3.Lerp(gun.transform.position, adsTransform.position, speed * Time.deltaTime);
            isAiming = true;
        }
        else
        {
            gun.transform.position = Vector3.Lerp(gun.transform.position, hipFireTransform.position, speed * Time.deltaTime);
            isAiming = false;
        }

    }

    private void Shoot()
    {
        //
        if ((Input.GetKeyDown(KeyCode.Mouse0)) && Time.time > nextFire && remainingBullets > 0 && !isReloading)
        {
            nextFire = Time.time + fireRate;
            fire.Play();
            remainingBullets--;

            UpdateAmmoUI();

            Vector3 aim = this.transform.forward;
            aim = Quaternion.AngleAxis(Random.Range(0, currentAccuracy), UnityEngine.Vector3.up) * aim;
            aim = Quaternion.AngleAxis(Random.Range(0, 360), this.transform.forward) * aim;
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, aim, out hit, maxRange))
            {
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
            }
        }
    }

    public bool isMoving
    {
        get
        {
            if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)))
                return true;
            else
                return false;
        }
    }

    private void PerformReload()
    {
        reloadTimer -= Time.deltaTime;
        reloadSlider.value = reloadTime - reloadTimer; // Update TMP slider value
        if (reloadTimer <= 0)
        {
            remainingBullets = 6;
            isReloading = false;
            reloadTimer = 0;
            reloadSlider.gameObject.SetActive(false); // Hide TMP slider when reload is complete
            UpdateAmmoUI();
            reloadingSound.Stop(); // Stop the reloading sound when reloading is complete
        }
    }

    public void Reload()
    {
        // Method to reload the gun
        if (Input.GetKeyDown(KeyCode.R) && remainingBullets < 6)
        {
            isReloading = true;
            reloadTimer = reloadTime;
            reloadSlider.gameObject.SetActive(true); // Show TMP slider when reload starts
            reloadSlider.minValue = 0;
            reloadSlider.maxValue = reloadTime;
            reloadingSound.Play(); // Start the reloading sound

            UpdateAmmoUI();
        }
    }

    private void UpdateAmmoUI()
    {
        // Update ammo count UI
        ammoText.text = "Ammo: " + remainingBullets + "/6";
    }

}