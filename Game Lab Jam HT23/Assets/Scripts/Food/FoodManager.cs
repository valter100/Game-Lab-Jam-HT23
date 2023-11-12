using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodManager : MonoBehaviour
{
    [SerializeField] GameObject[] foodPrefabs;
    [SerializeField] GameObject[] foodSpawnPoints;
    [SerializeField] Slider foodSlider;

    [SerializeField] public int startAmountOfFood;
    [Range(0, 1)]
    [SerializeField] float difficulty;

    List<GameObject> foodList;

    public static FoodManager instance;


    private void Awake()
    {
        if (instance == null)
            instance = this;

        GetSpawnPoints();
        StartDay();
        foodList = new List<GameObject>();

        
    }

    public void StartDay()
    {
        ResetFoodSlider();
    }

    public void GetSpawnPoints()
    {
        foodSpawnPoints = GameObject.FindGameObjectsWithTag("FoodSpawn");
        Array.Reverse(foodSpawnPoints);
    }

    public void SpawnFood(int amount, float difficulty)
    {
        difficulty = Mathf.Clamp01(difficulty);

        int maxSpawnLength = (int)(foodSpawnPoints.Length * difficulty);
        int minSpawnLength = (int)(foodSpawnPoints.Length * (difficulty * 0.5f));

        int?[] takenSpots = new int?[foodSpawnPoints.Length];

        for (int i = 0; i < amount; ++i)
        {
            //Random food
            int rf = UnityEngine.Random.Range(0, foodPrefabs.Length);
            //Random spawnpoint
            int rs = UnityEngine.Random.Range(minSpawnLength, maxSpawnLength);

            while (takenSpots[rs] != null)
            {
                rs++;
            }

            takenSpots[rs] = 1;
            foodList.Add(Instantiate(foodPrefabs[rf], foodSpawnPoints[rs].transform.position, Quaternion.identity));
        }
    }
    public void UpdateSliderOnFoodPickup() //increase value of slider when food is picked up
    {
        foodSlider.value++;
    }
    public void ResetFoodSlider() //set slider to max available food and value to 0
    {
        foodSlider.maxValue = startAmountOfFood;
        foodSlider.value = 0;
    }

    public void ResetAndSpawnFood()
    {
        foreach (var food in foodList)
        {
            Destroy(food);
        }

        foodList.Clear();

        SpawnFood(startAmountOfFood, difficulty);
    }

    public void UpdateDifficulty()
    {
        difficulty += 0.1f;
        difficulty = Mathf.Clamp(FoodManager.instance.difficulty, 0.1f, 0.9f);
    }
}
