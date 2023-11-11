using System;
using UnityEngine;
using UnityEngine.UI;

public class FoodManager : MonoBehaviour
{
    [SerializeField] GameObject[] foodPrefabs;
    [SerializeField] GameObject[] foodSpawnPoints;
    [SerializeField] Slider foodSlider;
    private int maxAvailableFood = 0; //food available to pick up in current level/day
    [SerializeField] public int startAmountOfFood;
    [Range(0, 1)]
    [SerializeField] float difficulty;

    public static FoodManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        GetSpawnPoints();
        StartDay();
    }

    public void StartDay()
    {
        SpawnFood(startAmountOfFood, difficulty);
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
        int minSpawnLength = (int)(foodSpawnPoints.Length * (difficulty * 0.5));

        int?[] takenSpots = new int?[foodSpawnPoints.Length];

        for (int i = 0; i < amount; ++i)
        {
            //Random food
            int rf = UnityEngine.Random.Range(0, foodPrefabs.Length);
            //Random spawnpoint
            int rs = UnityEngine.Random.Range(minSpawnLength, maxSpawnLength);

            while (takenSpots[rs] != null)
            {
                rs += UnityEngine.Random.Range(0, 3);
            }

            takenSpots[rs] = 1;
            Instantiate(foodPrefabs[rf], foodSpawnPoints[rs].transform.position, Quaternion.identity);
            maxAvailableFood++;
        }
    }
    public void UpdateSliderOnFoodPickup() //increase value of slider when food is picked up
    {
        foodSlider.value++;
    }
    public void ResetFoodSlider() //set slider to max available food and value to 0
    {
        foodSlider.maxValue = maxAvailableFood;
        foodSlider.value = 0;
    }
}
