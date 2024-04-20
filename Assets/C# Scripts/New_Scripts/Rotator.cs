using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 10f;

    void Update()
    {
        // Rotate the GameObject around the y-axis in world space
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }
}