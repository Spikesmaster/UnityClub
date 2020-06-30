using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

[RequireComponent(typeof(NavMeshAgent))]
public class DroneManager : MonoBehaviour
{

    public GameObject droneDepotUI;
    public TextMeshProUGUI regionNameUI;
    public string regionNameString;
    public GameObject destinationUI;
    public float droneSpeed;
    public bool destinationWanted = false;
    
    public bool isInTransit = false;

    public float droneWaterPayloadSize, droneFoodPayloadSize;
    public GameObject currentDestination;

    public void NewDroneSelected ()
    {
        if (!destinationWanted && !isInTransit) 
        {
            droneDepotUI.SetActive(true);
            regionNameUI.text = regionNameString;
        }
    }

    public float destinationDistanceOffset;
    public void SelectDroneDestination(GameObject outpostDestination){
        
        if (destinationWanted == true)
        {
            //resource taken
            currentDestination.GetComponent<ResourceManagement>().waterSupply -= droneWaterPayloadSize;
            //
            currentDestination = outpostDestination;
            destinationUI.SetActive(false);
            NavMeshAgent agent = transform.GetComponent<NavMeshAgent>();
            agent.speed = droneSpeed;
            agent.destination = outpostDestination.transform.position;
            agent.stoppingDistance = destinationDistanceOffset;
            isInTransit = true;
            
            
        }
    }
    void FixedUpdate()
    {
        if(transform.GetComponent<NavMeshAgent>().remainingDistance<=destinationDistanceOffset&&isInTransit){
            destinationWanted = false;
            isInTransit = false;
            Debug.Log("test");
            //resource added
            currentDestination.GetComponent<ResourceManagement>().waterSupply += droneWaterPayloadSize;
        }
    }


}
