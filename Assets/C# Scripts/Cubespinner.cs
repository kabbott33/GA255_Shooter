using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpinner : MonoBehaviour
{
    public Light bruh;
    private float singularity;

    public float spinSpeed;

    // Start is called before the first frame update
    void Start()
    {
        singularity = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        singularity = singularity * 1.001f;
        //this.transform.Rotate(0, 0.1f * spinSpeed, 0.1f * spinSpeed);
        //this.transform.Rotate(0.1f * spinSpeed, 0.1f * spinSpeed, 0);
        this.transform.Rotate(singularity,singularity,singularity);
    }
}
