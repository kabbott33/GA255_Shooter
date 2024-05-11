using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    private int destroyedControlPanels = 0;
    public int health = 3;
    public GameObject door;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (destroyedControlPanels == health)
        {

            Destroy(this.gameObject);
            Destroy(door.gameObject);
        }
    }

    public void ControlPanelDestroyed()
    {
        destroyedControlPanels++;
    }
}
