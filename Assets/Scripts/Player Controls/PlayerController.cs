using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private SphereCollider playerCollider;
    private Light powerUpIndicato;
    private Transform focalpoint;
    private float moveForceMagnitude;
    private float moveDirection;
    public bool hasPowerUp { get; private set; }

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnEnable()
    {

    }

    void OnDisable()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {

    }

    private void OnMovementCancceled(InputAction.CallbackContext value)
    {

    }

    private void AssignLevelValues()
    {

    }

    private void Move()
    {

    }

    private void OnColliderEnter(Collision collision)
    {

    }

    private void OnTriggerEnter(Collider other)
    {

    }

    private IEnumerator PowerUpCooldown(float cooldown)
    {
        return null;
    }
}