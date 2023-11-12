using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatInformation : MonoBehaviour
{
    List<string> hatNames;

    private void Start()
    {
        hatNames = new List<string>(); 

        if(hatNames.Count > 0)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void AddHat(GameObject hat)
    {
        hatNames.Add(hat.name);
    }

    public List<string> GetHatNames() { return hatNames; }
}
