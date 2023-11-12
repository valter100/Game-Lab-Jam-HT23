using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatInformation : MonoBehaviour
{
    [SerializeField] List<string> hatNames;

    private void Start()
    {
        HatInformation[] infos = FindObjectsOfType<HatInformation>();

        foreach (HatInformation info in infos)
        {
            if(info != this)
            {
                Destroy(info.gameObject);
                break;
            }
        }

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
