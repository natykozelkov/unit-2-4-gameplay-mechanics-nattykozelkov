using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/********************************************
 * SpawnManager is the component of the SpawnManager.
 * 
 * Naty Kozelkova
 * January 29, 2024 Version 1.0
 *******************************************/


public class SpawnManager : MonoBehaviour
{
    [Header("Objects to Spawn")]
    [SerializeField] private GameObject iceSphere, portal, powerUp;

    [Header("Wave Fields")]
    [SerializeField] private int initialWave, increaseEachWave, maximumWave;

    [Header("Portal Fields")]
    [SerializeField] private int portalFirstAppearance;
    [SerializeField] private float portalByWaveProbability, portalByWaveDuration;

    [Header("PowerUp Fields")]
    [SerializeField] private int powerUpFirstAppearance;
    [SerializeField] private float powerUpByWaveProbability, powerUpByWaveDuration;

    [Header("Island")]
    [SerializeField] private GameObject island;

    private Vector3 islandSize;
    private int waveNumber;
    private bool portalActive;
    private bool powerUpActive;

    // Start is called before the first frame update
    void Start()
    {
        islandSize = island.GetComponent<MeshCollider>().bounds.size;
        waveNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (GameObject.Find("Player") != null && FindObjectsOfType<IceSphereController>().Length <= 0)
        {
            SpawnIceWave();
        }

        if (waveNumber > portalFirstAppearance || (GameManager.Instance.debugSpawnPortal = true && !gameObject.CompareTag("Portal")))
        {
            SetObjectActive(portalByWaveProbability, portal);
        }
    }

    void SpawnIceWave()
    {
        for(int i = 0; i < waveNumber; i++)
        {
            Instantiate(iceSphere, SetRandomPosition(1.6f), iceSphere.transform.rotation);
        }
        if(waveNumber < maximumWave)
        {
            waveNumber++;
        }
    }

    void SetObjectActive(float byWaveProbability, GameObject obj)
    {
        if (Random.value < waveNumber * byWaveProbability * Time.deltaTime)
        {
            obj.transform.position = SetRandomPosition(-0.65f);
            StartCoroutine(CountdownTimer(obj.tag));

        }
    }

    Vector3 SetRandomPosition(float posY)
    {
        float randomX = Random.Range(-islandSize.x / 2, islandSize.x / 2);
        float randomZ = Random.Range(-islandSize.z / 2, islandSize.z / 2);

        return new Vector3(randomX, posY, randomZ);
    }

    // It begins running without taking over control of the script's execution meaning
    // It eneables the portal, waits and the disables it again
    IEnumerator CountdownTimer(string objectTag)
    {
        float byWaveDuration = 0;

        switch (objectTag)
        {
            case "Portal":
                portal.SetActive(true);
                portalActive = true;
                byWaveDuration = portalByWaveDuration;
                break;
        }

        yield return new WaitForSeconds(waveNumber * byWaveDuration);

        switch (objectTag)
        {
            case "Portal":
                portal.SetActive(false);
                portalActive = false;
                break;
        }
    }
}