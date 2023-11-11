using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Rat"))
        {
            other.GetComponent<Rat>().EquipHat(this);
            Destroy(this);
        }
    }
}
