using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reticle : MonoBehaviour
{
    public RectTransform reticle;
    // Start is called before the first frame update
    public float size;
    public float restingSize;
    public float maxSize;
    public float speed;
    private float currentSize;

    void Start()
    {
        reticle = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        reticle.sizeDelta = new Vector2 (size, size);

        if (isMoving)
        {
            currentSize = Mathf.Lerp (currentSize, maxSize,Time.deltaTime * speed);
        }
        else
        {
            currentSize = Mathf.Lerp(currentSize, restingSize, Time.deltaTime * speed);

        }
        reticle.sizeDelta = new Vector2(currentSize, currentSize);

        
    }

    bool isMoving
    {
        get 
        {
            if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)))
                return true;
            else
                return false;

               
        }
    }
}
//((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0) || (Input.GetAxis("Mouse X") != 0) || (Input.GetAxis("Mouse Y") != 0))