using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int health = 100;
    public TextMeshProUGUI healthText;
    public float invincibilityTimer = 3.0f;
    public bool canTakeDamage = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (canTakeDamage == true)
            {
                
                TakeDamage(3);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

            HealDamage(2);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthText.text = "health:" + health;
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            canTakeDamage = false;
            StartCoroutine(InvincibilityCo());
        }
    }


    public void HealDamage(int healing) 
    {
        health += healing;
        if(health >= maxHealth)
        {
            health = maxHealth;        }
        healthText.text = "health:" + health;
    }

    IEnumerator InvincibilityCo()
    {
        yield return new WaitForSeconds(invincibilityTimer);
        canTakeDamage = true;



    }
}
