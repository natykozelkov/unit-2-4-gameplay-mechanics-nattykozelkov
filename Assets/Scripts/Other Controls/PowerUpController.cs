using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/********************************************
 * PowerUpController is the component of the PowerUp.
 * 
 * Naty Kozelkova
 * February 28, 2024 Version 1.0
 *******************************************/

public class PowerUpController : MonoBehaviour
{
    [SerializeField] private float cooldown;
    [SerializeField] private float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetCooldown()
    {
        return cooldown;
    }
}
