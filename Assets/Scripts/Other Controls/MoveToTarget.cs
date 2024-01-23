using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/********************************************
 * MoveToTarget is the component of the Ice Sphere.
 * 
 * Naty Kozelkova
 * January 23, 2024 Version 1.0
 *******************************************/


public class MoveToTarget : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;

    private GameObject target;
    private Rigidbody targetRb;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        targetRb = target.GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        navMeshAgent.SetDestination(targetRb.transform.position);
    }
}
