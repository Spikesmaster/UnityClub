using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WorkerAudioResponse : MonoBehaviour
{

#pragma warning disable 0649
    [SerializeField]
    AudioClip clickSound;
    [SerializeField]
    AudioClip flyingSound;

#pragma warning restore 0649
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
