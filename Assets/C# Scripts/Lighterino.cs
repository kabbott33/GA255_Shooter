using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighterino : MonoBehaviour
{
    public Light light1;
    public Light light2;
    public GameObject lightObject;
    // Start is called before the first frame update
    void Start()
    {
        lightObject.GetComponent<Light>().color = Color.white;
        light1.color = Color.green;
        light1.color = new Color(1f, 0.2f, 0.57f, .9f);
       // light1.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
