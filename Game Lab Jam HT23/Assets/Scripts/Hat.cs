using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{
    [SerializeField] Vector3 ratSize;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Rat"))
        {
            transform.localScale = ratSize;
            other.GetComponent<Rat>().EquipHat(this);
            Destroy(gameObject);
        }
    }

}
