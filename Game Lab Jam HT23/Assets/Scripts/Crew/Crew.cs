using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Crew : MonoBehaviour
{
    [SerializeField] int numberOfPeople = 50;
    int deadPeople = 0;
    int infectedPeople = 0;

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
        get { return numberOfPeople; }
    }

    void Start()
    {
        
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
