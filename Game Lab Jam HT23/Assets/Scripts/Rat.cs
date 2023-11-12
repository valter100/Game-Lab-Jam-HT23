using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{

    [SerializeField] float infectionRadius = 5f;
    [SerializeField] float infectionRate = 5f;

    [SerializeField] float fleas;
    [SerializeField] int foodCollected;

    [SerializeField] float timeBetweenFleaPickup;
    float timeSinceLastFleaPickup;
    [SerializeField] ParticleSystem fleasSystem;
    [SerializeField] ParticleSystem radiusSystem;
    [SerializeField] Crew crewScript;


    [SerializeField] float distanceFlea = 10f;
    [SerializeField] AudioSource pickupFoodSource;
    [SerializeField] AudioSource pickupHatSource;
    [SerializeField] Transform hatPosition;
    float currentDistanceFlee = 0f;
    [SerializeField] GameObject currentHat;
    [SerializeField] List<GameObject> hats;
    [SerializeField] int hatAmount;
    [SerializeField] int currentHatIndex;
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
        hats = new List<GameObject>();

        var shape = radiusSystem.shape;
        shape.radius = fleas;
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

        CheckHatIndexPress();
    }

    public void PickupFlea()
    {
        fleas += 0.5f;
        infectionRadius = fleas;

        var shape = radiusSystem.shape;
        shape.radius = fleas;
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
            pickupFoodSource.Play();
            foodCollected++;
        }
        if (other.CompareTag("Hat"))
        {
            pickupHatSource.Play();
        }
    }

    public void EquipHat(Hat newHat)
    {
        if(hatAmount > 0)
        {
            if (hats[currentHatIndex])
                hats[currentHatIndex].SetActive(false);
        }

        GameObject SpawnedHat = Instantiate(newHat.gameObject, hatPosition.position, Quaternion.identity);
        Destroy(SpawnedHat.GetComponent<Hat>());
        hats.Add(SpawnedHat);

        hatAmount++;
        currentHatIndex = hatAmount - 1;
        currentHat = SpawnedHat;
    }

    public void CheckHatIndexPress()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            if(hatAmount > 0)
            {
                hats[currentHatIndex].SetActive(false);
                currentHatIndex = 0;
                hats[currentHatIndex].SetActive(true);
                currentHat = hats[currentHatIndex];
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (hatAmount > 1)
            {
                hats[currentHatIndex].SetActive(false);
                currentHatIndex = 1;
                hats[currentHatIndex].SetActive(true);
                currentHat = hats[currentHatIndex];
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (hatAmount > 2)
            {
                hats[currentHatIndex].SetActive(false);
                currentHatIndex = 2;
                hats[currentHatIndex].SetActive(true);
                currentHat = hats[currentHatIndex];
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (hatAmount > 3)
            {
                hats[currentHatIndex].SetActive(false);
                currentHatIndex = 3;
                hats[currentHatIndex].SetActive(true);
                currentHat = hats[currentHatIndex];
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (hatAmount > 4)
            {
                hats[currentHatIndex].SetActive(false);
                currentHatIndex = 4;
                hats[currentHatIndex].SetActive(true);
                currentHat = hats[currentHatIndex];
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (hatAmount > 5)
            {
                hats[currentHatIndex].SetActive(false);
                currentHatIndex = 5;
                hats[currentHatIndex].SetActive(true);
                currentHat = hats[currentHatIndex];
            }
        }
    }
}
