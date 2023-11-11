using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource dayAudioSource;
    [SerializeField] AudioSource nightAudioSource;
    AudioSource currentAudioSource;
    [SerializeField] float musicVolume;
    [SerializeField] float musicSwitchDuration;
    //AudioClip currentAudio;

    // Start is called before the first frame update
    void Start()
    {
        currentAudioSource = dayAudioSource;
        currentAudioSource.volume = musicVolume;
        currentAudioSource.Play();
    }

    public void ToggleMusic()
    {
        if(currentAudioSource == dayAudioSource)
            StartCoroutine(lerpMusic(nightAudioSource));
        else
            StartCoroutine(lerpMusic(dayAudioSource));


    }

    public IEnumerator lerpMusic(AudioSource newSource)
    {
        float progress = 0f;
        float rate = 1 / musicSwitchDuration;
        newSource.Play();
        
        while (progress < 1)
        {
            progress += rate * Time.deltaTime;

            currentAudioSource.volume = Mathf.Lerp(musicVolume, 0, progress);
            newSource.volume = Mathf.Lerp(0, musicVolume, progress);
            yield return 0;

        }

        currentAudioSource.volume = 0;
        currentAudioSource.Stop();
        newSource.volume = musicVolume;

        currentAudioSource = newSource;

        yield return 0;
    }
}
