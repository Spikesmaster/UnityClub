﻿using System;
using UnityEngine;
public class PauseMenu : MonoBehaviour
{
    public static event Action<bool>  PauseToggleEvent;
    bool isPaused;

    public GameObject pausePanel;

    [SerializeField]
    public KeyCode pauseKey;

    void Start ()
    { 
        isPaused = false;
    }
    void Update()
    {
        ListenForPauseInput();
    }

    void ListenForPauseInput()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        PauseToggleEvent?. Invoke(isPaused);
        pausePanel.SetActive(isPaused);
    }
}