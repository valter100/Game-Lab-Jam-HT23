using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    [SerializeField] int fleas;
    [SerializeField] int requiredFood;
    [SerializeField] int infectionRadius;
    [SerializeField] float timeBetweenFleaPickup;
    float timeSinceLastFleaPickup;
    [SerializeField] ParticleSystem fleasSystem;

    void Start()
    {
        
    }

    // Fleas increases when rat is walking
    // Fleas affects the infection radius
    // Food matters 
    void Update()
    {
        
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
}
