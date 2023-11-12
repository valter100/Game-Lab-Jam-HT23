using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{

    [SerializeField] float infectionRadius = 5f;
    [SerializeField] float infectionRate = 5f;

    [SerializeField] float fleas = 1.5f;
    [SerializeField] int foodCollected;

    [SerializeField] float timeBetweenFleaPickup;
    float timeSinceLastFleaPickup;
    [SerializeField] ParticleSystem fleasSystem;
    [SerializeField] Crew crewScript;


    [SerializeField] float distanceFlea = 10f;
    [SerializeField] AudioSource pickupSource;
    [SerializeField] Transform hatPosition;
    float currentDistanceFlee = 0f;
    GameObject currentHat;
    Vector3 lastFramesPosition;

    public float InfectionRadius
    {
        get { return infectionRadius; }
    }
    public float InfectionRate
    {
        get { return infectionRate; }
    }

    void Start()
    {
        lastFramesPosition = transform.position;
        infectionRadius = fleas;
        infectionRate = fleas;
    }

    // Fleas increases when rat is walking
    // Fleas affects the infection radius
    // Food matters 
    void Update()
    {
        for (int i = 0; i < crewScript.CrewMates.Length; i++)
        {
            float distance = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(crewScript.CrewMates[i].transform.position.x, 0, crewScript.CrewMates[i].transform.position.z));
            if (distance < (infectionRadius / 2))
            {
                crewScript.CrewMates[i].IncreaseInfection(infectionRate * 2);
            }
            else if (distance < infectionRadius)
            {
                crewScript.CrewMates[i].IncreaseInfection(infectionRate);
            }
        }

        CheckFlea();

        if(currentHat)
        {
            currentHat.gameObject.transform.position = hatPosition.position;
            currentHat.transform.rotation = transform.rotation;
        }
    }

    public void PickupFlea()
    {
        fleas += 0.5f;
        infectionRadius = fleas;
        infectionRate = fleas;
    }

    public void CheckFlea()
    {
        float deltaDifference = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(lastFramesPosition.x, 0, lastFramesPosition.z));
        currentDistanceFlee += deltaDifference;

        if(currentDistanceFlee > distanceFlea)
        {
            currentDistanceFlee = 0;
            PickupFlea();
        }
        lastFramesPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            other.GetComponentInParent<FoodCollectible>().CollectFood();
            pickupSource.Play();
            foodCollected++;
        }
    }

    public void EquipHat(Hat newHat)
    {
        if(currentHat)
            Destroy(currentHat);

        GameObject SpawnedHat = Instantiate(newHat.gameObject, hatPosition.position, Quaternion.identity);
        Destroy(SpawnedHat.GetComponent<Hat>());
        currentHat = SpawnedHat;
    }
}
