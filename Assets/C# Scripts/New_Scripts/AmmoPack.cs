using System.Collections;
using TMPro;
using UnityEngine;

public class AmmoPack : MonoBehaviour
{
    public int amount = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Shooting playerAmmo = GameObject.Find("PlayerCamera").GetComponent<Shooting>();
            if (playerAmmo != null)
            {
                playerAmmo.AddAmmo(amount);
                Destroy(gameObject);
            }
        }
    }
}