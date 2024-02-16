using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/********************************************
 * PlayerController is the component of the Player. In this project, 
 * the player only moves forward.
 * 
 * Naty Kozelkova
 * January 16, 2024 Version 1.0
 *******************************************/

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private SphereCollider playerCollider;
    private Light powerUpIndicator;
    private Transform focalpoint;
    private float moveForceMagnitude;
    private float moveDirection;
    public bool hasPowerUp { get; private set; }
    private GameManager gameManager;
   

    private PlayerInputActions inputAction;

    private void Awake()
    {
        inputAction = new PlayerInputActions();
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        playerRB = GetComponent<Rigidbody>();
        playerCollider = GetComponent<SphereCollider>();
        powerUpIndicator = GetComponent<Light>();
        gameManager = GetComponent<GameManager>();

        playerCollider.material.bounciness = 0.4f;
        powerUpIndicator.intensity = 0f;
        hasPowerUp = true;

    }

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

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        if(transform.position.y < -10)
        {
            GameManager.Instance.gameOver = true;
            Debug.Log("You Lost");
        }
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveDirection = value.ReadValue<Vector2>().y;
    }

    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        moveDirection = 0f;
    }

    private void AssignLevelValues()
    {
        transform.localScale = GameManager.Instance.playerScale;
        playerRB.mass = GameManager.Instance.playerMass;
        playerRB.drag = GameManager.Instance.playerDrag;
        moveForceMagnitude = GameManager.Instance.playerMoveForce;
        focalpoint = GameObject.Find("Focal Point").transform;
        gameObject.layer = LayerMask.NameToLayer("Player");
    }
  
    private void Move()
    {
        if (focalpoint != null)
        {

            Debug.Log(focalpoint.forward.normalized * moveForceMagnitude * moveDirection);
            playerRB.AddForce(focalpoint.forward.normalized * moveForceMagnitude * moveDirection);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Startup"))
        {
            collision.gameObject.tag = "Ground";
            playerCollider.material.bounciness = GameManager.Instance.playerBounce;
            AssignLevelValues();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Portal"))
        {
            gameObject.layer = LayerMask.NameToLayer("Portal");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Portal"))
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
            if(transform.position.y <= other.transform.position.y - 1f)
            {
                transform.position = Vector3.up * 25;
                GameManager.Instance.switchLevels = true;
            }
        }
    }

    private IEnumerator PowerUpCooldown(float cooldown)
    {
        return null;
    }
}