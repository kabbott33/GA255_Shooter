using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PHealth : MonoBehaviour
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

    public void Hit(int dmg)
    {
        health -= dmg;
        healthText.text = "health:" + health;
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            canTakeDamage = false;
            StartCoroutine(InvincibilityCo());
        }
    }

   
    // Update is called once per frame
    void Update()
    {
        

    }
    IEnumerator InvincibilityCo()
    {
        yield return new WaitForSeconds(invincibilityTimer);
        canTakeDamage = true;



    }
}
