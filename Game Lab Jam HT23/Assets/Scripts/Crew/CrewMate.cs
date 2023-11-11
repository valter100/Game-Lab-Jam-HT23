using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Crew;

public class CrewMate : MonoBehaviour
{

    public bool alive = true;

    [SerializeField] float infectionLevel = 0;

    float infectionCooldown = 0.2f;
    float infectionCooldownReset = 0.2f;

    Material material;

    Color orignialColor;
    Color finalColor = new Color(129f, 255f, 0f , 255);

    [SerializeField] AudioSource audioSource;

    public float InfectionLevel
    {
        get { return infectionLevel; }
    }

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
            {
                material = transform.GetChild(i).GetComponent<Renderer>().material;
                break;
            }
        }
        orignialColor = finalColor;
    }

    // Update is called once per frame
    void Update()
    {
        material.color = Color.Lerp(Color.white, Color.green, infectionLevel/100f);
        audioSource.Play();
    }
    public void NPCTalk(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
        material.color = Color.Lerp(Color.white, Color.green, infectionLevel/100f);
    }
    public void IncreaseInfection(float infection)
    {
        if (infectionCooldown <= 0)
        {
            infectionLevel += infection;
            infectionCooldown = infectionCooldownReset;
        }
        else
        {
            infectionCooldown -= Time.deltaTime;
        }

        if (infectionLevel >= 100)
        {
            alive = false;
        }

        
    }

    private void OnTriggerStay(Collider other)
    {
    }
}
