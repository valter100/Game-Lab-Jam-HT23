using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Crew : MonoBehaviour
{
    [SerializeField] int numberOfPeople = 40;
    CrewMate[] crewMates;
    int valueOfPeople = 4;
    int deadPeople = 0;
    int infectedPeople = 0;

    public enum HealthState { healthy, infected, dead };

    

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Vector3[] spawnLocations;

    public int DeadPeople
    { 
        get { return deadPeople; }
    }
    public int InfectedPeople
    {
        get { return infectedPeople; }
    }

    public int NumberOfPeople
    {
        get { return numberOfPeople; }
    }

    void Start()
    {
        crewMates = new CrewMate[numberOfPeople / valueOfPeople];
        //for (int i = 0; i < crewMates.Length; i++)
        //{
        //    crewMates[i] = Instantiate();
        //}
    }

    void Update()
    {
        
    }

    public void PrintCrew()
    {
        text.enabled = true;
        text.text = "Number of alive crewmates: " + (numberOfPeople - (infectedPeople + deadPeople)) + "\n" + "Number of infected crewmates: " + infectedPeople + "\n" + "Number of dead crewmates: " + deadPeople;
    }

    public void DisableCrewText()
    {
        text.enabled = false;
    }
}
