using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleToggler : MonoBehaviour
{
    public GameObject reticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1)) 
        {
            reticle.SetActive(false);
        }
        else
        {
             reticle.SetActive(true);
        }
    }
}   
