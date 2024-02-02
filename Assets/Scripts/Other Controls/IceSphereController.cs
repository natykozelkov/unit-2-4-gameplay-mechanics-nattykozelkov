using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/********************************************
 * IceSphereController is the component of the Ice Sphere.
 * 
 * Naty Kozelkova
 * January 24, 2024 Version 1.0
 *******************************************/

public class IceSphereController : MonoBehaviour
{
    [SerializeField] private float startDelay, reductionEachRepeat, minimumVolume;
    

    private Rigidbody iceRB;
    private ParticleSystem iceVFX;
    private float pushForce;

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.Instance.debugSpawnWaves)
        {
            reductionEachRepeat = .5f;
        }

        iceRB = GetComponent<Rigidbody>();
        iceVFX = GetComponent<ParticleSystem>();
        RandomizeSizeAndMass();

        InvokeRepeating("Melt", startDelay, 0.3f);
    }

    void RandomizeSizeAndMass()
    {
        Vector3 originalScale = transform.localScale;
        float originalMass = GetComponent<Rigidbody>().mass;

        float randomScalePercent = Random.Range(0.5f, 1.0f);
        float randomMassPercent = Random.Range(0.5f, 1.0f);

        //creating a random new mass and scale that is 50% - 100% of the Ice Spehre
        Vector3 newScale = originalScale * randomScalePercent;
        float newMass = originalMass * randomMassPercent;

        transform.localScale = newScale;
        GetComponent<Rigidbody>().mass = newMass;
    }

    void Dissolution()
    {
        Destroy(gameObject);
    }

    void Melt()
    {
        float volume = 4f / 3f * Mathf.PI * Mathf.Pow(transform.localScale.x, 3);

        if(volume > minimumVolume)
        {
            transform.localScale *= reductionEachRepeat;
            GetComponent<Rigidbody>().mass *= reductionEachRepeat;
        }
        else
        {
            Dissolution();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
