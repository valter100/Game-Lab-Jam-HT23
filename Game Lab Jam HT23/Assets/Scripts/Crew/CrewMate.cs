using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewMate : MonoBehaviour
{

    Crew.HealthState state = Crew.HealthState.healthy;

    public int daysSick { get; private set; } = 0;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InfectionRadius"))
        {
            state = Crew.HealthState.infected;
        }
    }
}
