// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PauseMenu1 : MonoBehaviour
// {
//     public static bool isPaused;
//     [SerializeField]
//     KeyCode pauseKey;

//     void Start () 
//     { 
//         isPaused = false;
//     }

//     void Update()
//     {
//         ListenForPauseInput();
//     }
//     void ListenForPauseInput()
//     {
//         if (Input.GetKeyDown(pauseKey))
//         { 
//             TogglePause();}
//         }
//     void TogglePause()
//     {
//         isPaused != isPaused; // Not sure what the error is?
//     }
// }