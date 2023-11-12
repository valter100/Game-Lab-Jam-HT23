using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Crew : MonoBehaviour
{
    int alivePeople;
    [SerializeField] CrewMate[] crewMates;
    int deadPeople = 0;

    [SerializeField] TextMeshProUGUI text;

    [SerializeField] AudioClip[] voiceClips;
    AudioClip nextClip;
    bool isPlaying = false;
    [SerializeField] float timeBetweenAudioCLips;
    float timeSinceLastAudioClip = 0;

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
        if (isPlaying)
            timeSinceLastAudioClip += Time.deltaTime;
        if (timeSinceLastAudioClip > timeBetweenAudioCLips)
        {
            timeSinceLastAudioClip = 0;
            Rat rat = FindObjectOfType<Rat>();
            CrewMate closest = crewMates[0];
            for (int i = 1; i < crewMates.Length; i++)
            {
                if (crewMates[i].alive && Vector3.Distance(crewMates[i].transform.position, rat.transform.position) < Vector3.Distance(closest.transform.position, rat.transform.position))
                {
                    closest = crewMates[i];
                }
            }

            if (nextClip == null)
            {
                int rnd;

                do
                {
                    rnd = Random.Range(0, voiceClips.Length);
                } while (rnd == 20 || rnd == 22);

                closest.NPCTalk(voiceClips[rnd]);


                if (rnd == 19 || rnd == 21)
                {
                    nextClip = voiceClips[rnd + 1];
                }
            }
            else
            {
                closest.NPCTalk(nextClip);
                nextClip = null;
            }

        }
    }

    public void StartPlay() { isPlaying = true; }
    public void StopPlay() { isPlaying = false; }

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
