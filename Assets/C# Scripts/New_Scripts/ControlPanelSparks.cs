using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanelSparks : MonoBehaviour
{
    public AudioSource bzzt;
    // Start is called before the first frame update
    void Start()
    {
        bzzt = GetComponent<AudioSource>();
        bzzt.Play();

        Invoke("DestroySelf", 3);
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
