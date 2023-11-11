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

    [SerializeField] AudioClip[] audioClips;
    [SerializeField] float timeBetweenAudioClips;
    float timeSinceLastAudioClip;

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
        timeSinceLastAudioClip += Time.deltaTime;

        if (timeSinceLastAudioClip > timeBetweenAudioClips)
        {
            timeSinceLastAudioClip = 0;

            Rat rat = GameObject.FindObjectOfType<Rat>();

            CrewMate closest = crewMates[0];

            for (int i = 1; i < crewMates.Length; i++)
            {
                if (crewMates[i].isActiveAndEnabled && Vector3.Distance(rat.transform.position, crewMates[i].transform.position) > Vector3.Distance(rat.transform.position, closest.transform.position))
                {
                    closest = crewMates[i];
                }
            }

            int rnd = Random.Range(0, audioClips.Length);

            closest.NPCTalk(audioClips[rnd]);
        }
    }

    public void PrintCrew()
    {
        text.enabled = true;
        text.text = "Number of alive crewmates: " + (alivePeople) + "\n" + "Number of dead crewmates: " + deadPeople;
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
