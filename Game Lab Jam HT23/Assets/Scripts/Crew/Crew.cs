using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Crew : MonoBehaviour
{
    int alivePeople;
    [SerializeField] CrewMate[] crewMates;
    int deadPeople = 0;

    [SerializeField] TextMeshProUGUI text;

    public CrewMate[] CrewMates
    {
        get { return crewMates; }
    }

    public int DeadPeople
    { 
        get { return deadPeople; }
    }

    public int NumberOfPeople
    {
        get { return alivePeople; }
    }

    void Start()
    {
        crewMates = GameObject.FindObjectsOfType<CrewMate>();
        alivePeople = crewMates.Length; 
    }

    void Update()
    {
        
    }

    public void PrintCrew()
    {
        text.enabled = true;
        text.text = "Number of alive crewmates: " + (alivePeople) + "\n"  + "Number of dead crewmates: " + deadPeople;
    }

    public void DisableCrewText()
    {
        text.enabled = false;
    }

    public void HandleCrew()
    {
        deadPeople = 0;
        alivePeople = crewMates.Length;

        for (int i = 0; i < crewMates.Length; i++)
        {
            if (!crewMates[i].alive)
            {
                deadPeople++;
                alivePeople--;
                crewMates[i].gameObject.SetActive(false);
            }
        }
    }
}
