using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;

    public List<Transform> patrolPaths;

    private int patrolPathIndex = 0;

    private GameObject player;

    private bool aggroed = false;

    private float distanceToPlayer;

    public float aggroRange;

    public AudioClip aggroSound;

    public float friendlyAggroRadius;
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
        distanceToPlayer = Vector3.Distance(this.transform.position, player.transform.position);

        if (navMeshAgent.remainingDistance < 0.5f && !aggroed)
        {
            patrolPathIndex++;
            if (patrolPathIndex >= patrolPaths.Count)
            {
                patrolPathIndex = 0;
            }

            navMeshAgent.destination = patrolPaths[patrolPathIndex].position;
        }/*
        Vector3 aim = player.transform.position - this.transform.position;
        Raycast hit;
        if (distanceToPlayer <= aggroRange || aggroed)
        {
            if (Physics.Raycast(this.transform.position, aim, out hit, aggroRange)) 
        }
        */
          
        if (distanceToPlayer<aggroRange)
        {
            aggroed = true;

            AudioSource.PlayClipAtPoint(aggroSound, transform.position);
            this.GetComponent<EnemyShooting>().Shoot();

            RaycastHit[] allhits = Physics.SphereCastAll(this.transform.position, friendlyAggroRadius, this.transform.position);

            foreach (RaycastHit hit in allhits)
            {
                if (hit.collider.tag == "Enemy")
                {
                    hit.transform.parent.GetComponent<EnemyMovement>().SetAggroed();
                }
            }
        }


    }
    public void SetAggroed()
    {
        aggroed = true;
        Debug.Log("AGGRO");
    }


}
