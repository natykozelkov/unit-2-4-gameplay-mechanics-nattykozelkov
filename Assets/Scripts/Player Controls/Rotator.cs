using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/********************************************
 * The Rotator is the component of the FocalPoint
 * 
 * Naty Kozelkova
 * January 16, 2024 Version 1.0
 *******************************************/

public class Rotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    private PlayerInputActions inputAction;
    private float moveDirection;

    void Awake()
    {
        inputAction = new PlayerInputActions();
    }

    // Rotate the foal points which the camera is attached to
    void Update()
    {
        transform.Rotate(Vector3.up, moveDirection * rotationSpeed * Time.deltaTime);
    }

    //Add OnMovement events to inputAction's Player's movement
    void OnEnable()
    {
        inputAction.Enable();
        inputAction.Player.Movement.performed += OnMovementPerformed;
        inputAction.Player.Movement.canceled += OnMovementCanceled;
    }

    void OnDisable()
    {
        inputAction.Disable();
        inputAction.Player.Movement.performed -= OnMovementPerformed;
        inputAction.Player.Movement.canceled -= OnMovementCanceled;
    }

    void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveDirection = value.ReadValue<Vector2>().x;
    }

    void OnMovementCanceled(InputAction.CallbackContext value)
    {
        moveDirection = 0f;
    }
}
