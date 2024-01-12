using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    private PlayerInputActions inputAction;
    private float moveDirection;

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        
    }

    void OnDisable()
    {
        
    }

    void OnMovementPerformed(InputAction.CallbackContext value)
    {

    }

    void OnMovementCanceled(InputAction.CallbackContext value)
    {

    }
}
