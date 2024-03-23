using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject cannonBall;
    public Transform spawnPoint;
    public float cannonBallForce;
    public float rotationSpeed = 20f;


    // Start is called before the first frame update
    void Start()
    {
        CustomTest test = new()
        {
            randomAssValue = 3
        };
        test.printValue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.eulerAngles += new Vector3(0f, 0f, 1f) * rotationSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.eulerAngles -= new Vector3(0f, 0f, 1f) * rotationSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space)) 
        {
            GameObject cb = Instantiate(cannonBall, spawnPoint.position, this.transform.rotation);

            cb.GetComponent<Rigidbody>().AddForce(this.transform.up * cannonBallForce);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            cannonBallForce += 100;
          Debug.Log("Strength =" + cannonBallForce);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            cannonBallForce -= 100;
            Debug.Log("Strength =" + cannonBallForce);
        }
    }
}

public class CustomTest
{
    public CustomTest()
    {
        printValue();
    }

    public int randomAssValue = Random.Range(0, 5);

    public void printValue()
    {
        Debug.Log("Test value is " + randomAssValue + "!");
    }
}