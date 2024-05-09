using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update

    //public string respawnBool;
    public bool towerRespawn;
    public bool compoundRespawn;
    public bool pitRespawn;
    public bool bossRespawn;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (towerRespawn)
            {
                PHealth.instance.reachedTower = true;
            }
            if (compoundRespawn)
            {
                PHealth.instance.reachedCompound = true;
            }
            if (pitRespawn)
            {
                PHealth.instance.reachedPit = true;
            }
            if (bossRespawn)
            {
                PHealth.instance.reachedBossfight = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
