using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
     if (other.collider.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
