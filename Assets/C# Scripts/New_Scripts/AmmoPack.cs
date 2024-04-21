using System.Collections;
using TMPro;
using UnityEngine;

public class AmmoPack : MonoBehaviour
{
    public int ammoAmount = 20;
    public int grenadeAmount = 3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           GrenadeThrower playerGrenades = GameObject.Find("GrenadeThrowPoint").GetComponent<GrenadeThrower>();
            Shooting playerAmmo = GameObject.Find("PlayerCamera").GetComponent<Shooting>();
            if (playerAmmo&&playerGrenades != null)
            {
                playerAmmo.AddAmmo(ammoAmount);
                playerGrenades.AddGrenades(grenadeAmount);
                Destroy(gameObject);
            }

           
        }
    }


}