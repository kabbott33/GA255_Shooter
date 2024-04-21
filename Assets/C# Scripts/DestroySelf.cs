using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float destroyDelay = 12.0f; // Delay in seconds before self-destructing

    void Start()
    {
        Destroy(gameObject, destroyDelay); // Destroy the GameObject after delay
    }
}