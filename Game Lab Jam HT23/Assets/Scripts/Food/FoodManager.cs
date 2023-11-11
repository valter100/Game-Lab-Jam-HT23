using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    [SerializeField] GameObject[] foodPrefabs;
    [SerializeField] GameObject[] foodSpawnPoints;

    private void Awake()
    {
        GetSpawnPoints();
        SpawnFood(0.2f);
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
    }
}
