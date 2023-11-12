using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandpa : MonoBehaviour
{
    HatInformation hatInfo;
    [SerializeField] List<string> hatNames;
    [SerializeField] List<GameObject> hats;
    [SerializeField] List<Transform> hatPositions;

    // Start is called before the first frame update
    void Start()
    {
        hatInfo = FindObjectOfType<HatInformation>(); 
        hatNames = hatInfo.GetHatNames();
        int index = 0;

        foreach(string hatName in hatNames)
        {
            foreach(GameObject hat in hats)
            {
                if(hatName == hat.name)
                {
                    Instantiate(hat, hatPositions[index]);
                    index++;
                    continue;
                }
            }
            index++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
