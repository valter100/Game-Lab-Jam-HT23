using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Crew;

public class CrewMate : MonoBehaviour
{

    public bool alive = true;

    [SerializeField] float infectionLevel = 0;

    float infectionCooldown = 0.2f;
    float infectionCooldownReset = 0.2f;

    public int maxDaysSick { get; private set; } = 0;

    public float InfectionLevel
    {
        get { return infectionLevel; }
    }

    void Start()
    {
        maxDaysSick = Random.Range(2, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InfectionRadius"))
        {
            
        }
    }

    public bool CheckIfAlive()
    {
        return alive;
    }

    public void IncreaseInfection(float infection)
    {
        if (infectionCooldown <= 0)
        {
            infectionLevel += infection;
            infectionCooldown = infectionCooldownReset;
        }
        else
        {
            infectionCooldown -= Time.deltaTime;
        }

        if (infectionLevel >= 100)
        {
            alive = false;
        }

        
    }
}
