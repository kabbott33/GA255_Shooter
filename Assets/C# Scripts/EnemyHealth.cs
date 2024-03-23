using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Bodyshot(int dmg)
    {
        health = health - dmg;
    }
    public void Headshot(int dmg)
    {
        health = health - 2*dmg;
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}
