using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Crew;

public class CrewMate : MonoBehaviour
{

    Crew.HealthState state = Crew.HealthState.healthy;

    public int daysSick { get; set; } = 0;

    [SerializeField] int infectionLevel = 0;

    public int maxDaysSick { get; private set; } = 0;

    public int InfectionLevel
    {
        get { return infectionLevel; }
    }

    public Crew.HealthState State 
    { 
        get 
        { 
            return state; 
        } 
        set
        {
            state = value;
        }
    }




    void Start()
    {
        maxDaysSick = Random.Range(2, 5);
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

    public bool CheckIfDead()
    {
        if (maxDaysSick >= daysSick)
        {
            State = HealthState.dead;
            return true;
        }
        return false;
    }
}
