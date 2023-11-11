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
    [SerializeField] Crew crewScript;


    [SerializeField] float distanceFlea = 10f;
    float currentDistanceFlee = 0f;

    Vector3 lastFramesPosition;

    [SerializeField] ParticleSystem fleaSystem;
    [SerializeField] ParticleSystem radiusSystem;
    


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
        fleas = infectionRadius;
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
    }

    public void PickupFlea()
    {
        fleas++;
        infectionRadius = fleas;
        var shape = radiusSystem.shape;

        shape.radius = infectionRadius;
        Debug.Log(shape.radius);
        var emission = fleaSystem.emission;
        emission.rateOverTime = fleas * 4f;
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
            foodCollected++;
        }
    }
    //public void OnDrawGizmos()
    //{
    //    Gizmos.DrawSphere(transform.position, infectionRadius);
    //}
}
