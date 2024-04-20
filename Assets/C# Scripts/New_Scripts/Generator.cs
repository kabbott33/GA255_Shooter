using System.Collections;
using System.Collections.Generic;
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


   // private bool isOpening;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bodyshot(int dmg)
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
                StartCoroutine(OpenDoor());
               // this.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    public void DestroyTurret()
    {
        Destroy(turret);
        Destroy(this.gameObject);
    }

    private IEnumerator OpenDoor()
    {

       
       // isOpening = true;
        

        // Start rotating towards the target rotation
        while ((Vector3.Distance(door.transform.position, doorOpenPosition.transform.position))>0.1f)
        {
            door.transform.position = Vector3.Lerp(door.transform.position, doorOpenPosition.transform.position, 5 * Time.deltaTime);
            //currentRotation = transform.rotation;
            // Wait for the next frame
            yield return null;
        }

        // Rotation completed
        //isOpening = false;

        Destroy(this.gameObject);
    }

}
