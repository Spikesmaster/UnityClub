using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovementManager : MonoBehaviour
{
    public GameObject currentDroneSelected;
    public void NewDestinationSelected(GameObject outpostDestination){

        currentDroneSelected.GetComponent<DroneManager>().SelectDroneDestination(outpostDestination);

    }

    public void SetNewCurrentDrone(GameObject newDrone){

        currentDroneSelected = newDrone;
    }
    public GameObject droneDepotUI;
    public GameObject destinationUI;
    //select resource
    public void ResourceSelection()
    {
        droneDepotUI.SetActive(false);
        destinationUI.SetActive(true);
        currentDroneSelected.GetComponent<DroneManager>().destinationWanted = true;
    }
}
