using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{

    [SerializeField] float infectionRadius = 1f;
    [SerializeField] float infectionRate = 1f;

    [SerializeField] int fleas;
    [SerializeField] int foodCollected;

    [SerializeField] float timeBetweenFleaPickup;
    float timeSinceLastFleaPickup;
    [SerializeField] ParticleSystem fleasSystem;
    [SerializeField] Crew crewScript;

    void Start()
    {
        
    }

    // Fleas increases when rat is walking
    // Fleas affects the infection radius
    // Food matters 
    void Update()
    {
        for (int i = 0; i < crewScript.CrewMates.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, crewScript.CrewMates[i].gameObject.transform.position);

            if (distance < (infectionRadius/2))
            {
                crewScript.CrewMates[i].IncreaseInfection(infectionRate * 2);
            }
            else if (distance < infectionRadius)
            {
                crewScript.CrewMates[i].IncreaseInfection(infectionRate);
            }
        }
    }

    public void PickupFlea()
    {

    }

    public void IncreaseMovementTimer()
    {
        timeSinceLastFleaPickup += Time.deltaTime;

        if(timeSinceLastFleaPickup > timeBetweenFleaPickup)
        {
            timeSinceLastFleaPickup = 0;
            PickupFlea();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            other.GetComponentInParent<FoodCollectible>().CollectFood();
            foodCollected++;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, infectionRadius);
    }
}
