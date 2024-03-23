using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkKnife : MonoBehaviour
{
    private Inventory inventory;
    public float interactDistance = 5f;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindObjectOfType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        DoorCheck();
    }

    void DoorCheck()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, interactDistance))
            {
                //Debug.Log(hit.collider.name);

                if (hit.collider.CompareTag("Door"))
                {
                    if (inventory.UseKey() == true)
                    {
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
    }
}
