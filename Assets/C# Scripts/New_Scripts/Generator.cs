using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Generator : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;


    public bool controlsDoor;
    public GameObject door;
    public Transform doorOpenPosition;

    public bool controlsTurret;
    public GameObject turret;

    public bool controlsBoss;
    public GameObject boss;

    public bool startsFight;
    public GameObject[] allTurrets;

    public AudioSource fightStartSound;

    public GameObject explosionPrefab;

    public bool blinking = true;
    public Material emissiveMaterial;

   // private bool isOpening;



    void Start()
    {
        
        emissiveMaterial = GetComponent<Renderer>().material;
        fightStartSound = this.GetComponent<AudioSource>();
        if (fightStartSound == null) fightStartSound = gameObject.AddComponent<AudioSource>();

        if ((controlsTurret) || (controlsBoss))
        {
            blinking = false;
            emissiveMaterial.DisableKeyword("_EMISSION");
            emissiveMaterial.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
        }
        else
        {
            blinking=true;
            StartCoroutine(Blink());

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!(blinking)&&(controlsTurret)){
            if (turret.GetComponent<Turret>().isAggroed)
            {
                blinking=true;
                StartCoroutine(Blink());
            }

        }
        if (!(blinking)&&(controlsBoss))
        {
            if (boss.GetComponent<Turret>().isAggroed)
            {
                blinking = true;
                StartCoroutine(Blink());
            }
        }

    }

    IEnumerator Blink()
    {
        
        emissiveMaterial.EnableKeyword("_EMISSION");
        emissiveMaterial.globalIlluminationFlags = MaterialGlobalIlluminationFlags.None;
        Debug.Log("on");
        //emissiveMaterial.SetColor("_EmissionColor", Color.white);
        yield return new WaitForSeconds(0.2f);
        emissiveMaterial.DisableKeyword("_EMISSION");
        emissiveMaterial.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
        Debug.Log("off");
        //emissiveMaterial.SetColor("_EmissionColor", Color.black);
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(Blink());
    }

    public void Bodyshot(int dmg)
    {
        if (blinking)
        {
            health -= dmg;
            if (health <= 0)
            {
                if (controlsTurret)
                {
                    DestroyTurret();
                }
                if (controlsDoor)
                {
                    Test();
                    //StartCoroutine(OpenDoor());
                    // this.GetComponent<MeshRenderer>().enabled = false;
                }
                if (controlsBoss)
                {
                    DamageBoss();
                }
                if (startsFight)
                {
                    fightStartSound.Play();
                    Invoke("StartFight", 5f);
                }

            }
        }

    }

    public void DamageBoss()
    {
        boss.GetComponent<BossHealth>().ControlPanelDestroyed();
        GameObject explosion = Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }

    public void DestroyTurret()
    {
        Destroy(turret);

        if (!startsFight) 
        {
            GameObject explosion = Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
            //explosion.transform.position += explosion.transform.forward / 1000;
            Destroy(this.gameObject);
        }
        
    }

    public void Test()
    {
        door.transform.position = doorOpenPosition.position;
        Destroy(this.gameObject);
        GameObject explosion = Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
    }
    private IEnumerator OpenDoor()
    {

       
       // isOpening = true;
        

        // Start rotating towards the target rotation
        while ((Vector3.Distance(door.transform.position, doorOpenPosition.transform.position))>0f)
        {
            door.transform.position = Vector3.Lerp(door.transform.position, doorOpenPosition.transform.position, 5 * Time.deltaTime);
            //currentRotation = transform.rotation;
            // Wait for the next frame
            yield return null;
        }

        // Rotation completed
        //isOpening = false;

        Destroy(this.gameObject);
        GameObject explosion = Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
    }

    private void StartFight()
    {

        Debug.Log("startfight");
        foreach (GameObject turret in  allTurrets)
        {
            turret.GetComponent<Turret>().Activate();
        }
        Destroy(this.gameObject) ;
        GameObject explosion = Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
    }
}
