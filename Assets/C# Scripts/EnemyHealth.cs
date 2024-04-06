using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    public AudioClip deathSound;

    // Start is called before the first frame update
    void Start()
    {
        // Get the EnemyMovement component attached to the same game object
        EnemyMovement enemyMovement = GetComponent<EnemyMovement>();

        if (enemyMovement == null)
        {
            Debug.LogError("EnemyMovement component not found!");
        }
    }

    public void Bodyshot(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
        else
        {
            // Call SetAggroed method on EnemyMovement when taking damage
            this.GetComponent<EnemyMovement>().SetAggroed();
        }
    }

    public void Headshot(int dmg)
    {
        health -= 2 * dmg;
        if (health <= 0)
        {
            Die();
        }
        else
        {
            // Call SetAggroed method on EnemyMovement when taking damage
            this.transform.parent.GetComponent<EnemyMovement>().SetAggroed();
        }
    }

    private void Die()
    {
        // Destroy the enemy game object
        Destroy(gameObject);

        // Play the death sound
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
    }
}