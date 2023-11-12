using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatInformation : MonoBehaviour
{
    List<GameObject> hats;

    private void Start()
    {
        hats = new List<GameObject>(); 

        if(hats.Count > 0)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void AddHat(GameObject hat)
    {
        DontDestroyOnLoad(hat.gameObject);
        hats.Add(hat);
    }

    public List<GameObject> GetHats() { return hats; }
}
