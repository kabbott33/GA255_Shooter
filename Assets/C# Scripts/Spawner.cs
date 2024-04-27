using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyGroup;
    // Start is called before the first frame update
    void Start()
    {
        enemyGroup.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyGroup.SetActive(true);
            Debug.Log(enemyGroup.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
