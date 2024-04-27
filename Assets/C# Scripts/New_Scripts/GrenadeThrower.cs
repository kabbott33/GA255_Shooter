using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrenadeThrower : MonoBehaviour
{
    public GameObject grenadePrefab;
    public TextMeshProUGUI grenadeCountText;
    public int grenadeCount = 3;

    public Transform throwPoint;

    void Update()
    {
        // Check if 'G' key is pressed and player has grenades
        if (Input.GetKeyDown(KeyCode.G) && grenadeCount > 0)
        {
            ThrowGrenade();
        }
    }

    void ThrowGrenade()
    {
        // Instantiate and throw grenade
        Instantiate(grenadePrefab, throwPoint.transform.position, throwPoint.transform.rotation);
        grenadeCount--;
        UpdateGrenadeCountUI();
    }

    public void AddGrenades(int amount)
    {
        grenadeCount = grenadeCount + amount;
        grenadeCountText.text = "Grenades: " + grenadeCount;
    }

    void UpdateGrenadeCountUI()
    {
        // Update UI to display remaining grenades
        grenadeCountText.text = "Grenades: " + grenadeCount;
    }
}