using System;
using UnityEngine;
using UnityEngine.UI;

public class FoodManager : MonoBehaviour
{
    [SerializeField] GameObject[] foodPrefabs;
    [SerializeField] GameObject[] foodSpawnPoints;
    [SerializeField] Slider foodSlider;
    private int maxAvailableFood = 0; //food available to pick up in current level/day

    private void Awake()
    {
        GetSpawnPoints();
        SpawnFood(0.2f);
        ResetFoodSlider();
    }

    public void GetSpawnPoints()
    {
        foodSpawnPoints = GameObject.FindGameObjectsWithTag("FoodSpawn");
        Array.Reverse(foodSpawnPoints);
    }

    public void SpawnFood(float difficulty)
    {
        difficulty = Mathf.Clamp01(difficulty);
 
        int maxSpawnLength = (int)(foodSpawnPoints.Length * difficulty);

        //Random food
        int rf = UnityEngine.Random.Range(0, foodPrefabs.Length);
        //Random spawnpoint
        int rs = UnityEngine.Random.Range(0, maxSpawnLength);

        Instantiate(foodPrefabs[rf], foodSpawnPoints[rs].transform.position, Quaternion.identity);
        maxAvailableFood++;
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
