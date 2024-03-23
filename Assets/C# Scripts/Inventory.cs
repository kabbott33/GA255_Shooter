using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
 
    public int numKeys;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddKey()
    {
        numKeys++;
    }

    public bool UseKey()
    {
        if (numKeys > 0)
        {
            numKeys--;
            return true;
        }
        else
        {
            Debug.Log("YOU ARE UNWORTHY");
            return false;
        }
    }
}
