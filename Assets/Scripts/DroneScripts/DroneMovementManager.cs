using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneMovementManager : MonoBehaviour
{
    GameObject currentDroneSelected;
    public GameObject choosePayloadUI, destinationUI; // UI where player chooses the resources; UI that asks the player to choose the destination.
    
    public float droneWaterPayloadSize, droneFoodPayloadSize, destinationDistanceOffset; // Variable for the amount of water that the drone can carry,
    //and the amount of food the drone can carry.
    public bool destinationWanted = false; // Variable that checks if player have choosen a destination already or not.    
    public bool isInTransit = false; // Variables that checks if drone is still moving or not.

    public bool waterWasChosen;
    public void NewDestinationSelected(GameObject outpostDestination) // When player clicks the outpost to where they want to move:
    {
        currentDroneSelected.GetComponent<DroneManager>().SelectDroneDestination(outpostDestination); // Activates the movement of the drone.
    }
    public void SetNewCurrentDrone(GameObject newDrone) // When player clicks a drone:
    {
        currentDroneSelected = newDrone; // Sets that to the current Drone.
    }
    public void WaterChosen() // If water button on the PayloadUI is pressed:
    {
        chosePayloadUIDisappears();
        waterWasChosen = true;
    }
    
    public void FoodChosen() // If food button on the PayloadUI is pressed:
    {
        chosePayloadUIDisappears();
        waterWasChosen = false;
    }
    void chosePayloadUIDisappears()
    {
        choosePayloadUI.SetActive(false); // Turn PayloadUI invisible.
        destinationUI.SetActive(true); // Turn DestinationUI visible.
        currentDroneSelected.GetComponent<DroneManager>().destinationWanted = true; // Turn destinationWanted true, so player can click on the destination.
    }
}