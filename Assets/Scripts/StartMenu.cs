using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void PlayGame(string sceneName)
    {
        SceneManager.LoadScene("Drones Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

// Code based on the unity assets.