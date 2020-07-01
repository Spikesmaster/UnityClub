using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneMovementManager : MonoBehaviour
{
    GameObject currentDroneSelected;
    public GameObject choosePayloadUI, destinationUI; // UI where player chooses the resources; UI that asks the player to choose the destination.
    
    public float droneSpeed, droneWaterPayloadSize, droneFoodPayloadSize, destinationDistanceOffset; // Variable for the speed of the drones, amount of water that the drone can carry,
    //amount of food the drone can carry, distance in between the drone and the final destination.    
    public bool destinationWanted = false; // Variable that checks if player have choosen a destination already or not.    
    public bool isInTransit = false; // Variables that checks if drone is still moving or not.
    public void NewDestinationSelected(GameObject outpostDestination) // When player clicks the outpost to where they want to move:
    {
        currentDroneSelected.GetComponent<DroneManager>().SelectDroneDestination(outpostDestination); // Activates the movement of the drone.
    }

    public void SetNewCurrentDrone(GameObject newDrone) // When player clicks a drone:
    {
        currentDroneSelected = newDrone; // Sets that to the current Drone.
    }
    public void WaterChoosen(GameObject currentDestination) // If water button on the PayloadUI is pressed:
    {
        choosePayloadUI.SetActive(false); // Turn PayloadUI invisible.
        destinationUI.SetActive(true); // Turn DestinationUI visible.
        currentDroneSelected.GetComponent<DroneManager>().destinationWanted = true; // Turn destinationWanted true, so player can click on the destination.
        currentDestination.GetComponent<ResourceManagement>().waterSupply += droneWaterPayloadSize; // Water is added to the current destination of the drone.
    }
    public void FoodChoosen(GameObject currentDestination) // If food button on the PayloadUI is pressed:
    {
        choosePayloadUI.SetActive(false); // Turn PayloadUI invisible.
        destinationUI.SetActive(true); // Turn DestinationUI visible.
        currentDroneSelected.GetComponent<DroneManager>().destinationWanted = true; // Turn destinationWanted true, so player can click on the destination.
        currentDestination.GetComponent<ResourceManagement>().foodSupply += droneFoodPayloadSize; // Water is added to the current destination of the drone.
    }
}