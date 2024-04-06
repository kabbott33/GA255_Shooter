using System.Collections;
using TMPro;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public int healthToAdd = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PHealth playerHealth = other.GetComponent<PHealth>();
            if (playerHealth != null)
            {
                playerHealth.AddHealth(healthToAdd);
                Destroy(gameObject);
            }
        }
    }
}