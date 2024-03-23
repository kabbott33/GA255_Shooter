using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoveController : MonoBehaviour
{

    public Transform cubeTeleportPosition;
    public Vector3 rotVector;
    public Vector3 scaleVector;

    public float movementSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.SetActive(false);
       // this.transform.position = new Vector3(1f, 0f, 0f);

        this.transform.position = cubeTeleportPosition.position;
        this.transform.eulerAngles = rotVector;
        this.transform.localScale = scaleVector;

    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = cubeTeleportPosition.position;
        //this.transform.eulerAngles = rotVector;
        //this.transform.localScale = scaleVector;

        if (Input.GetKey(KeyCode.D)) 
        {
            this.transform.position += Vector3.right * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey(KeyCode.A)) 
        {
            this.transform.position += Vector3.left * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey(KeyCode.W)) 
        {

            this.transform.position += Vector3.forward * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey(KeyCode.S)) 
        {
            this.transform.position += Vector3.back * Time.deltaTime * movementSpeed;
        }
    }
}
