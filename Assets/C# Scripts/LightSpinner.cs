using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManipulation : MonoBehaviour
{
    public Light bruh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0.1f, 0.1f, 0.1f);
    }
}
