using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night
{
    float currentNightLength = 40f;
    Vector3[] cheeseLocations;


    public float CurrentNightLength
    {
        get { return currentNightLength; }
        set { currentNightLength = value; }
    }


    public void UpdateTime()
    {
        currentNightLength -= Time.deltaTime;
    }
}
