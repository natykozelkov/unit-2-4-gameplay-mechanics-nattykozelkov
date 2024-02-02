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
    private float portalByWaveProbability, portalByWaveDuration;

    [Header("PowerUp Fields")]
    [SerializeField] private int powerUpFirstAppearance;
    private float powerUpByWaveProbability, powerUpByWaveDuration;

    [Header("Island")]
    [SerializeField] private GameObject island;

    private Vector3 islandSize;
    private int WaveNumber;
    private bool portalActive;
    private bool powerUpActive;

    // Start is called before the first frame update
    void Start()
    {
        islandSize = island.GetComponent<MeshCollider>().bounds.size;
        WaveNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player") != null && FindObjectsOfType<IceSphereController>().Length == 0)
        {
            SpawnIceWave();
        }
    }

    void SpawnIceWave()
    {
        for(int i = 0; i < WaveNumber; i++)
        {
            Instantiate(iceSphere, SetRandomPosition(1.6f), iceSphere.transform.rotation);
        }
        if(WaveNumber < maximumWave)
        {
            WaveNumber++;
        }
    }

    void SetObjectActive(float byWaveProbability, GameObject obj)
    {

    }

    Vector3 SetRandomPosition(float posY)
    {
        float randomX = Random.Range(-islandSize.x / 2, islandSize.x / 2);
        float randomZ = Random.Range(-islandSize.z / 2, islandSize.z / 2);

        return new Vector3(randomX, posY, randomZ);
    }

    IEnumerator CountdownTimer(string objectTag)
    {
        yield return null;
    }
}