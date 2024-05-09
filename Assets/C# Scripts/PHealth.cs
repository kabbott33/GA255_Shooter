using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PHealth : MonoBehaviour
{
    public static PHealth instance;
    public int maxHealth = 100;
    public int health = 100;
    public TextMeshProUGUI healthText;
    public float invincibilityTimer = 3.0f;
    public bool canTakeDamage = true;

    // Variables for fall damage
    public float fallDamageThresholdVelocity = -10f; // Threshold velocity in the negative Y direction to trigger fall damage
    public int maxFallDamage = 50; // Maximum fall damage

    private Rigidbody rb;
    private bool isGrounded = false;
    private bool hasFallen = false;

    public float fallVelocity;

    public float fallDamageMultiplier = 12f;


 //respawn stuff
    public bool reachedTower;
    public bool reachedCompound;
    public bool reachedPit;
    public bool reachedBossfight;

    public GameObject deathScreen;

    private Transform respawnPoint;
    //public Transform hell;


    void Start()
    {
        instance = this;
        healthText.text = "Health: " + health;
        rb = GetComponent<Rigidbody>();
    }

    public void Hit(int dmg)
    {
        health -= dmg;
        healthText.text = "Health: " + health;
        if (health <= 0)
        {
            StartCoroutine(Respawn());
        }
    }

    IEnumerator InvincibilityCo()
    {
        yield return new WaitForSeconds(invincibilityTimer);
        canTakeDamage = true;
    }

    public void AddHealth(int amount)
    {
        health = Mathf.Min(maxHealth, health + amount);
        healthText.text = "Health: " + health;
    }

    private void FixedUpdate()
    {
        if (!isGrounded && rb.velocity.y < fallDamageThresholdVelocity)
        {
            hasFallen = true;
            fallVelocity = Mathf.Abs(rb.velocity.y);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            if (hasFallen)
            {

                float fallDamageCalculation = (fallVelocity + fallDamageThresholdVelocity)*fallDamageMultiplier;
                int fallDamage = Mathf.RoundToInt(fallDamageCalculation);
                //fallDamage = Mathf.Clamp(fallDamage, 0, maxFallDamage);
                Debug.Log("fall damage:" + fallDamage);
                Hit(fallDamage);
                hasFallen = false;
            }
        }
    }

    IEnumerator Respawn()
    {
        health = 100;
        healthText.text = "Health: " + health;
        this.transform.position = GameObject.Find("Hell").transform.position;
        deathScreen.SetActive(true);
        yield return new WaitForSeconds(3);

        respawnPoint = GameObject.Find("StartSpawn").transform;
        if (reachedTower)
        {
            respawnPoint = GameObject.Find("TowerSpawn").transform;
        }
        if (reachedCompound)
        {
            respawnPoint = GameObject.Find("CompoundSpawn").transform;
        }
        if (reachedPit)
        {
            respawnPoint = GameObject.Find("PrePitSpawn").transform;
        }
        if (reachedBossfight)
        {
            respawnPoint = GameObject.Find("PreBossSpawn").transform;
        }
        this.transform.position = respawnPoint.position;
        this.transform.rotation = respawnPoint.rotation;
        deathScreen.SetActive (false);
    }
    /*
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            canTakeDamage = false;
            StartCoroutine(InvincibilityCo());
    */

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}