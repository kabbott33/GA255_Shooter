using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanelExplosion : MonoBehaviour
{
    public AudioSource boom;
    // Start is called before the first frame update
    void Start()
    {
        boom = GetComponent<AudioSource>();
        boom.Play();

        Invoke("DestroySelf", 5);
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
