using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowards : MonoBehaviour
{
    [SerializeField] GameObject focusObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(focusObject.transform.position);
    }
}
