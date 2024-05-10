using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Grenade : MonoBehaviour
{
    public float explosionTimer = 2f;
    public float explosionRadius = 5f;
    public int explosionDamage = 100;
    public AudioClip explosionSound;
    public float initialForce = 10f; // Adjust as needed
    public GameObject explosionPrefab;

    Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();

        // Apply impulse force in the forward direction
        rb.AddForce(transform.forward * initialForce, ForceMode.Impulse);

        // Invoke the Explode method after the explosion timer
        Invoke("Explode", explosionTimer);


    }

    void Explode()
    {
        // Play explosion sound
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);

        RaycastHit[] allhits = Physics.SphereCastAll(this.transform.position, explosionRadius, this.transform.position);

        foreach (RaycastHit hit in allhits)
        {
            if (hit.collider.tag == "Body")
            {
                hit.transform.parent.GetComponent<EnemyHealth>().Bodyshot(explosionDamage);
            }
            if (hit.collider.tag == "Generator")
            {
                hit.collider.GetComponent<Generator>().Bodyshot(explosionDamage);
            }
        }



        // Instantiate explosion visual effect
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, 0.2f); // Destroy the explosion after 1 second

        // Destroy grenade
        Destroy(gameObject);
    }
}