using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float targetPoints;
    private ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
       // scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Projectile"))
            {
           // UnityEngine.Debug.Log("Ganas" + targetPoints + "puntos!");

            scoreManager.AddScore(targetPoints);

            Destroy(other.gameObject);
            }
    }
}
