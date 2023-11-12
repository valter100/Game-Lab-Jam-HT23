using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandpa : MonoBehaviour
{
    HatInformation hatInfo;
    List<GameObject> hats;
    [SerializeField] List<Transform> hatPositions;

    // Start is called before the first frame update
    void Start()
    {
        hatInfo = FindObjectOfType<HatInformation>(); 
        hats = hatInfo.GetHats();
        int index = 0;
        foreach(GameObject hat in hats)
        {
            hat.transform.position = hatPositions[index].position;
            hat.transform.rotation = hatPositions[index].rotation;
            index++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
