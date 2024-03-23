using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindObjectOfType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inventory.AddKey();
            Destroy(this.gameObject);
        }
    }
}
