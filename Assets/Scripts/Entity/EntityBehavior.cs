using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EntityBehavior : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> patrolSpotList = new List<GameObject>();
    [SerializeField]
    private float speed = 50;
    [SerializeField]
    private float minRemainingDistance = 0.5f;

    private NavMeshAgent agent = null;

    private int destinationPoint = 1;


    // Start is called before the first frame update
    void Start()
    {
        FillPatrolSpotsList();

        agent = GetComponent<NavMeshAgent>();

        if(agent == null)
        {
            Debug.LogError("Your NavMeshAgent is null, please set one");
            return;
        }

        //Set all properties the agent need
        SetAgentProperties();
        //Go to the first Patrol Spot we want, then Update()
        GoToNextPatrolSpot();

        //entityAgent.destination = lastPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < minRemainingDistance)
        {
            GoToNextPatrolSpot();
        }
    }

    void SetAgentProperties()
    {
        agent = GetComponent<NavMeshAgent>();
        if(agent == null)
        {
            Debug.LogError("Your NavMeshAgent is null, please set one");
            return;
        }

        agent.speed = speed;
        agent.acceleration = speed * 10;
        agent.autoBraking = true;
        agent.angularSpeed = 10;
        agent.stoppingDistance = 0;
    }

    void FillPatrolSpotsList()
    {
        foreach (GameObject target in GameObject.FindGameObjectsWithTag("patrolPoint"))
        {
            patrolSpotList.Add(target.gameObject);
/*            Debug.Log(target.name);
            Debug.Log(target.transform.position);*/
        }

        if (patrolSpotList[1] == null) //First index otherwise it will take the spots group and go to 0,0,0
        {
            Debug.LogError("There are no Patrol Spots in your List, please setup some.");
            return;
        }
    }

    void GoToNextPatrolSpot()
    {
/*        Debug.Log(patrolSpotList[destinationPoint].name);
        Debug.Log(patrolSpotList[destinationPoint].transform.position);*/

        if (patrolSpotList.Count <= 1)
        {
            Debug.LogError("You must setup at least one Patrol Spot for your Entity.");
            return;
        }

        agent.destination = patrolSpotList[destinationPoint].transform.position;

        destinationPoint = (destinationPoint + 1) % patrolSpotList.Count;
    }
}
