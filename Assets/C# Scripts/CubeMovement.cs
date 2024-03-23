using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PLAYERMOVEMENT : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    public Rigidbody rb;

    private float verticalInput;
    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Space))
        {
            this.rb.AddForce(Vector3.up * 10000f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            this.rb.AddForce(Vector3.down * 10000f * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(0f, 0f, verticalInput * Time.fixedDeltaTime);
        movement = transform.TransformDirection(movement);
        rb.AddForce(movement * speed * 100, ForceMode.Acceleration);

        float rotation = horizontalInput * rotateSpeed * 10 * Time.deltaTime;
        transform.Rotate(Vector3.up, rotation);
    }
}
