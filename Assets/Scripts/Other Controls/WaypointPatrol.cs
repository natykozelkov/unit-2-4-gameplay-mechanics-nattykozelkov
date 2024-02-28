using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/********************************************
 * WaypointPatrol is the component of the IceSphere.
 * 
 * Naty Kozelkova
 * February 27, 2024 Version 1.0
 *******************************************/

public class WaypointPatrol : MonoBehaviour
{
    private GameObject[] waypoints;
    private NavMeshAgent navMestAgent;
    private int waypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = GameManager.Instance.waypoints;
        navMestAgent = GetComponent<NavMeshAgent>();
        waypointIndex = Random.Range(0, waypoints.Length);
    }

    // Update is called once per frame
    void Update()
    {
        MoveToNextWaypoint();
    }

    void MoveToNextWaypoint()
    {
        navMestAgent.SetDestination(waypoints[waypointIndex].transform.position);
        if (!navMestAgent.pathPending && navMestAgent.remainingDistance < 0.1f)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
        }
    }
}
