using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

/********************************************
 * GameManager is the component of the GameMananger
 * 
 * Naty Kozelkova
 * January 16, 2024 Version 1.0
 *******************************************/

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player Fields")]
    public Vector3 playerScale;
    public float playerMass;
    public float playerDrag;
    public float playerMoveForce;
    public float playerRepelForce;
    public float playerBounce;

    [Header("Scene Fields")]
    public GameObject[] waypoints;

    [Header("Debug Fields")]
    public bool debugSpawnWaves;
    public bool debugSpawnPortal;
    public bool debugSpawnPowerUp;
    public bool debugPowerUpRepel;

    public bool switchLevels { get; set; }
    public bool gameOver { get; set; }
    public bool playerHasPowerUp { get; set; }

    // This assign the GameManager script to an instace of GameManager called Instance.
    // It allows another class to get the field values of the GameManager.
    void Awake()
    {
        // Awake is called before any Start methods are called.
        // This is a common approach to handling a class with a reference to itself.
        // If instance variable doesn't exist, assign this object ti it.

        if (Instance == null)
        {
            Instance = this;
        }

        // Otherwise, if the instance variable does exist. but it isn't this object, destroy this object.
        // This is useful ao that we cannot have more than one GameManager object un a scene at a time.

        else if(Instance != this)
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(switchLevels)
        {
            SwitchLevels();
        }
    }

    void EnablePlayer()
    {

    }

    void SwitchLevels()
    {
        switchLevels = false;

        string currentScene = SceneManager.GetActiveScene().name;

        int nextLevel = int.Parse(currentScene.Substring(5)) + 1;

        if(nextLevel <= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene("Level " + nextLevel.ToString());
        }
        else
        {
            gameOver = true;
            Debug.Log("You Won");
        }
    }
}
