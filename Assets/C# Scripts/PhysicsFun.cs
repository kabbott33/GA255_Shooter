using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsFun : MonoBehaviour
{
    public Rigidbody rb;
    public float forceMultiplier = 20f;
    public Vector3 cannonVector;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(cannonVector * forceMultiplier);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
