using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] Night[] nights;
    [SerializeField] int amountOfNights;

    [SerializeField] float nightLength = 10f;
    int currentNight = 0;

    [SerializeField] float lightIntensity = 1f;

    [SerializeField] Light dirLight;
    [SerializeField] TextMeshProUGUI text;

    [SerializeField] int requiredFood = 3;

    bool night = true;

    [SerializeField] float dayTime = 2f;
    float dayTimeReset = 0f;
    float firstDayTimer;
    float firstDayTimerReset;

    [SerializeField] Camera dayCamera;
    [SerializeField] Camera nightCamera;

    [SerializeField] Material dayMaterial;
    [SerializeField] Material nightMaterial;
    Vector3 ratCameraLocation;

    [SerializeField] GameObject[] food;

    [SerializeField] Vector3[] spawnPoints;

    [SerializeField] Crew crewScript;
    [SerializeField] GameObject rat;

    [SerializeField] Slider slider;
    [SerializeField] Slider foodSlider;
    [SerializeField] Image dayNightImage;
    float dayRotateValue;
    float nightRotateValue;

    [SerializeField] MusicManager musicManager;

    public bool Night
    {
        get { return night; }
    }

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
        ratCameraLocation = rat.transform.position;

        dayRotateValue = 180 / dayTime;
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
            dayNightImage.transform.Rotate(new Vector3(0, 0, dayRotateValue * Time.deltaTime));
            dirLight.intensity = Mathf.Lerp(0, lightIntensity, firstDayTimer / firstDayTimerReset);
            return;
        }


        if (nights[currentNight].CurrentNightLength > 0)
        {
            if (!night)
            {
                FoodManager.instance.ResetAndSpawnFood();
                FoodManager.instance.UpdateDifficulty();
                rat.GetComponent<Rat>().FoodCollected = 0;
                FoodManager.instance.ResetFoodSlider();
                text.enabled = false;
                crewScript.DisableCrewText();
                night = true;
                nightRotateValue = 180 / nights[currentNight].CurrentNightLength;
                musicManager.ToggleMusic();
                SwitchToNightCamera();
            }

            nights[currentNight].UpdateTime();
            dayNightImage.transform.Rotate(new Vector3(0, 0, nightRotateValue * Time.deltaTime));
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
            SceneManager.LoadScene(5);
            return;
        }
        if (crewScript.DeadPeople > crewScript.CrewMates.Length / 1.5f)
        {
            SceneManager.LoadScene(4);
            return;
        }

        if (rat.GetComponent<Rat>().FoodCollected < requiredFood)
        {
            SceneManager.LoadScene(3);
            return;
        }

        // Makes sure this only happens once per night
        if (night)
        {
            SwitchToDayCamera();
            musicManager.ToggleMusic();
            crewScript.HandleCrew();
            ShowNightText("Night: " + (currentNight + 2).ToString());
            RenderSettings.skybox = dayMaterial;
        }

        dayTime -= Time.deltaTime;
        dayNightImage.transform.Rotate(new Vector3(0, 0, dayRotateValue * Time.deltaTime));
        dirLight.intensity = Mathf.Lerp(0, lightIntensity, dayTime / firstDayTimerReset);
        if (dayTime < 0)
        {
            currentNight++;
        }
        slider.value = currentNight + 1;
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
        rat.transform.position = ratCameraLocation;
        //nightCamera.transform.position = ratCameraLocation;
        nightCamera.enabled = true;
        dayCamera.enabled = false;
        slider.gameObject.SetActive(false);
        RenderSettings.skybox = nightMaterial;
    }

    public void SwitchToDayCamera()
    {
        dayCamera.enabled = true;
        dayCamera.GetComponent<Animator>().Play("DayCameraMovement");
        nightCamera.enabled = false;
        slider.gameObject.SetActive(true);
        RenderSettings.skybox = dayMaterial;
    }
}
