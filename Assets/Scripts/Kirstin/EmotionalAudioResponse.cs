using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionalAudioResponse : MonoBehaviour
{
    public AudioClip[] audioClips;   
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start( )
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            audioSource.PlayOneShot(audioClips[0]);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            audioSource.PlayOneShot(audioClips[1]);         
        }
        else 
        {
            //do nothing, I dont care.
        }

        }


    }
