using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

[RequireComponent(typeof(NavMeshAgent))]
public class DroneManager : MonoBehaviour
{
    public GameObject choosePayloadUI; // UI where player chooses the resources.
    public TextMeshProUGUI regionNameUI; // Variable for the name of the Region to be changed on the choosePayloadUI, 
    //depending where the drone is when player touches it.
    public GameObject destinationUI; // UI that asks the player to choose the destination.
    public float droneSpeed, droneWaterPayloadSize, droneFoodPayloadSize, destinationDistanceOffset; // Variable for the speed of the drones, amount of water that the drone can carry,
    //amount of food the drone can carry, ??? This is the localization of the Outposts, but I don't understand how this works ???.
    public bool destinationWanted = false; // Variable that checks if player have choosen a destination already or not.    
    public bool isInTransit = false; // Variables that checks if drone is still moving or not.
    public GameObject currentOutpost; // Sets the destination of the Drones.
    float currentPayload = 0;
    GameObject droneMovementManagerGO;
    
    void Awake() 
    {
        droneMovementManagerGO = GameObject.Find("DroneUIResourcesManager");//TODO remove hardcode name here
    }
    public void NewDroneSelected () // Method to choose the Drone clicked. This Method is called by the Event Trigger that is in every drone.
    // When the player touched the drone, the event trigger calls this line of code.
    {
        if (!destinationWanted && !isInTransit) // This code only works if drone is not moving and player never clicked a drone.
        {
            choosePayloadUI.SetActive(true); // When a drone is clicked: changes the choosePayloadUI to visible.
            regionNameUI.text = "Region: " + currentOutpost.transform.name; // Changes the name of the region to the region where the Drone is, when player clicks it.
        }
    }
    public void SelectDroneDestination(GameObject outpostDestination) // When player clicks a Destination, the event trigger on every outpost triggers this code:
    {  
        if (destinationWanted == true) // (This variable turns into true on the DroneMovementManager Script, after player choosing a destination). If the destinationWanted is true: 
        {
            destinationUI.SetActive(false); // "Choose Outpost" UI goes to false.
            if(droneMovementManagerGO.GetComponent<DroneUIResourcesManager>().waterWasChosen == true)
            {
                currentPayload = currentOutpost.GetComponent<ResourceManagement>().ConsumeWater(droneWaterPayloadSize);
            }
            if(droneMovementManagerGO.GetComponent<DroneUIResourcesManager>().foodWasChosen == true)
            {
                currentPayload = currentOutpost.GetComponent<ResourceManagement>().ConsumeFood(droneFoodPayloadSize);
            }
            NavMeshAgent agent = transform.GetComponent<NavMeshAgent>(); // Activates the navigation of the drone.
            agent.speed = droneSpeed; // Looks for the speed of the drone choosen and uses it.
            agent.destination = outpostDestination.transform.position; // Moves the drone to the outpost that was clicked.
            agent.stoppingDistance = destinationDistanceOffset; // ??? This is when the drone should stop, but also no idea how this is really working ???
            GetComponent<AudioSource>().Play();
            isInTransit = true; // Turns the variable that checks if the drone is moving true (so player can't touch drone while this is flying).
            currentOutpost = outpostDestination; // Changes the current destination to destination of the outpost that was clicked.         
        }
    }
    void FixedUpdate() // Checking if drone reached the destination.
    {
        if(transform.GetComponent<NavMeshAgent>().remainingDistance<=destinationDistanceOffset&&isInTransit) // If the remaining distance is equal or smaller than the localization of the outposts
        // and the drone is moving, this code happens:
        {
            destinationWanted = false; // Variable that allows player to choose the destination goes to false, again.
            isInTransit = false; // Variable that allows drone to move, turns false and drone stops moving.
            CheckingResourcesDebug(); // Calls the method when drone reaches the destination.
            GetComponent<AudioSource>().Stop();
            if(droneMovementManagerGO.GetComponent<DroneUIResourcesManager>().waterWasChosen == true)
            {
                //to do the same with resource consumption
                currentOutpost.GetComponent<ResourceManagement>().AddWater(currentPayload);
                droneMovementManagerGO.GetComponent<DroneUIResourcesManager>().waterWasChosen = false;
            }
            if(droneMovementManagerGO.GetComponent<DroneUIResourcesManager>().foodWasChosen == true)
            {
                //to do the same with resource consumption
                currentOutpost.GetComponent<ResourceManagement>().AddFood(currentPayload);
                droneMovementManagerGO.GetComponent<DroneUIResourcesManager>().foodWasChosen = false;
            }
            currentPayload = 0;
        }
    }
    void CheckingResourcesDebug() // Debug just to check the amount of resources we have (delete in the future)
    {
        Debug.Log("Water supplies: " + currentOutpost.GetComponent<ResourceManagement>().waterSupply); 
        Debug.Log("Food supplies: " + currentOutpost.GetComponent<ResourceManagement>().foodSupply);
    }
}