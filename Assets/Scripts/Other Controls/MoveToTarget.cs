using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/********************************************
 * MoveToTarget is the component of the Ice Sphere.
 * 
 * Naty Kozelkova
 * January 22, 2024 Version 1.0
 *******************************************/


public class MoveToTarget : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;

    private GameObject target;
    private Rigidbody targetRB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveTowardsTarget()
    {

    }
}
