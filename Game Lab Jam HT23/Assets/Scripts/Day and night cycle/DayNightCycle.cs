using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] Night[] nights;
    [SerializeField] int amountOfNights;
    [SerializeField] float nightLength = 10f;
    int currentNight = 0;

    [SerializeField] float lightIntensity = 1f;

    [SerializeField] Light dirLight;
    [SerializeField] TextMeshProUGUI text;

    bool night = true;

    [SerializeField] float dayTime = 2f;
    float dayTimeReset = 0f;
    float firstDayTimer;
    float firstDayTimerReset;

    [SerializeField] Camera dayCamera;
    [SerializeField] Camera nightCamera;


    [SerializeField] GameObject[] food;
    [SerializeField] Vector3[] spawnPoints;

    [SerializeField] Crew crewScript;

    void Start()
    {
        dayTimeReset = dayTime;
        firstDayTimer = dayTime;
        firstDayTimerReset = dayTime;
        nights = new Night[amountOfNights];
        for (int i = 0; i < amountOfNights; i++)
        {
            nights[i] = new Night();
            nights[i].CurrentNightLength = nightLength;
        }

        SwitchToDayCamera();
    }

    void Update()
    {
        if (nights.Length == 0)
        {
            return;
        }

        if (firstDayTimer > 0)
        {
            ShowNightText("Night: " + "1");
            firstDayTimer -= Time.deltaTime;
            dirLight.intensity = Mathf.Lerp(0, lightIntensity, firstDayTimer / firstDayTimerReset);
            return;
        }


        if (nights[currentNight].CurrentNightLength > 0)
        {
            if (!night)
            {
                text.enabled = false;
                crewScript.DisableCrewText();
                night = true;

                SwitchToNightCamera();
            }

            nights[currentNight].UpdateTime();
            dirLight.intensity = Mathf.Lerp(lightIntensity, 0, nights[currentNight].CurrentNightLength / nightLength);
        }
        else
        {
            Day();
        }
    }

    public void Day()
    {
        if (currentNight == nights.Length - 1)
        {
            //Victory
            ShowNightText("VICTORY!!");
            return;
        }
        // Makes sure this only happens once per night
        if (night)
        {
            SwitchToDayCamera();
            ShowNightText("Night: " + (currentNight + 2).ToString());
            
        }

        dayTime -= Time.deltaTime;
        dirLight.intensity = Mathf.Lerp(0, lightIntensity, dayTime / firstDayTimerReset);
        if (dayTime < 0)
        {
            currentNight++;
        }
    }

    public void ShowNightText(string currentNight)
    {
        
        text.enabled = true;
        text.text = (currentNight);

        crewScript.PrintCrew();
        dayTime = dayTimeReset;

        night = false;
    }



    public void SwitchToNightCamera()
    {
        nightCamera.enabled = true;
        dayCamera.enabled = false;
    }

    public void SwitchToDayCamera()
    {
        dayCamera.enabled = true;
        nightCamera.enabled = false;
    }
}