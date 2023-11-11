using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject followObject;
    [SerializeField] Vector3 Offset;
    // Start is called before the first frame update
    void Start()
    {
        Offset = transform.position - followObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = followObject.transform.position + Offset;
    }
}
