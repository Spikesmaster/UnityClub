using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DroneAudioResponse : MonoBehaviour
{

    public AudioClip[] audioclips;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayRandomSong()
    {
        int index = UnityEngine.Random.Range(0, audioclips.Length);
        audioSource.clip = audioclips[index];
        audioSource.Play();
    }
}
