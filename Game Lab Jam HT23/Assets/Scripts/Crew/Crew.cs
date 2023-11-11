using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Crew : MonoBehaviour
{
    int alivePeople;
    [SerializeField] CrewMate[] crewMates;
    int valueOfPeople = 4;
    int deadPeople = 0;
    int infectedPeople = 0;

    public enum HealthState { healthy, infected, dead };

    

    [SerializeField] TextMeshProUGUI text;

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
        get { return alivePeople; }
    }

    void Start()
    {
        alivePeople = crewMates.Length;
    }

    void Update()
    {
        
    }

    public void PrintCrew()
    {
        text.enabled = true;
        text.text = "Number of alive crewmates: " + (alivePeople - (infectedPeople + deadPeople)) + "\n" + "Number of infected crewmates: " + infectedPeople + "\n" + "Number of dead crewmates: " + deadPeople;
    }

    public void DisableCrewText()
    {
        text.enabled = false;
    }

    public void HandleCrew()
    {
        deadPeople = 0;
        infectedPeople = 0;
        for (int i = 0; i < crewMates.Length; i++)
        {
            if (crewMates[i].State == HealthState.dead)
            {
                deadPeople++;
                continue;
            }
            if (crewMates[i].CheckIfDead())
            {
                deadPeople++;
                return;
            }

            if (crewMates[i].InfectionLevel >= 100)
            {
                infectedPeople++;
                crewMates[i].daysSick++;
            }
        }
    }
}
