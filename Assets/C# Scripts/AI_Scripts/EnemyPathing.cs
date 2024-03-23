using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyPathing : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;

    public List<Transform> patrolPaths;

    private int patrolPathIndex = 0;

    private GameObject player;

    private bool isChasingPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.destination = patrolPaths[0].position;

       // navMeshAgent.destination = patrolPath1.position;
    }

    // Update is called once per frame
    void Update()
    {
   

        if (navMeshAgent.remainingDistance < 0.5f)
        {
            patrolPathIndex++;
            if (patrolPathIndex >= patrolPaths.Count) 
            {
                patrolPathIndex = 0;
            }

            navMeshAgent.destination = patrolPaths[patrolPathIndex].position;
        }


       
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Something was hit!");
         if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("The Player was hit!");
            RaycastHit hit;
            Vector3 direction = player.transform.position - this.transform.position;
            direction = direction.normalized;
            if (Physics.Raycast(this.transform.position, direction, out hit, 10f))
            {
                {
                    Debug.Log("The Player is in his line of sight. Chase him xD!!!");
                    navMeshAgent.destination = hit.collider.transform.position;
                    isChasingPlayer = true;
                }
            }
        }
    }

}
