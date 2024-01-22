using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/********************************************
 * PowerInteractor is the component of the Ice Sphere.
 * 
 * Naty Kozelkova
 * January 22, 2024 Version 1.0
 *******************************************/


public class PowerInteractor : MonoBehaviour
{
    [SerializeField] private float pushForce;

    private Rigidbody iceSphereRB;
    private IceSphereController iceSphereController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
