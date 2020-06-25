using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class DronePayloadController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject droneDepotUI;
    public TextMeshProUGUI regionName;
    public GameObject destinationUI;
    public GameObject volcanoDest, mountainDest, mainDomeDest, rainforestDest;
    private NavMeshAgent agent;
    public float speedOfAgent;
    public float payloadDropTime;
    private bool destinationWanted = false;
    public GameObject largePayloadController;
    
    // void Start() 
    // {
    //     agent = largePayloadController.GetComponent<NavMeshAgent>();   
    // }
    
    void OnMouseDown()
    {
        if (destinationWanted == false)
        {
            if (gameObject.CompareTag("LargeDrone"))
            {
                Debug.Log("OnMouseDown");
                droneDepotUI.SetActive(true);
                regionName.text = "Mountain Outpost"; //the region the drone is currently at
            }

            if (gameObject.CompareTag("SmallDrone"))
            {
                Debug.Log("OnMouseDown");
                droneDepotUI.SetActive(true);
                regionName.text = "Rainforest";
            }
        }

    //     if (destinationWanted == true)
    //     {
    //         if (gameObject.CompareTag("Volcanic"))
    //         {
    //             Debug.Log("Got here");
                
    //         }

    //         // if (gameObject.CompareTag("Rainforest"))
    //         // {
    //         //     Debug.Log("Got here");
    //         //     agent = GetComponent<NavMeshAgent>();
    //         //     agent.speed = speedOfAgent;
    //         //     agent.destination = destination.transform.position;
    //         // }
    //     }
    }
    void Update() 
        {
            Debug.Log("Destination wanted: " + destinationWanted);
            // if (agent.remainingDistance <= agent.stoppingDistance)
            // {
            //     destinationWanted = false;
            // }

            agent = largePayloadController.GetComponent<NavMeshAgent>();
        }
    public void DestinationSelection()
    {
        droneDepotUI.SetActive(false);
        destinationUI.SetActive(true);
        destinationWanted = true;
    }

    public void AIBitVolcano()
    {
        if (destinationWanted == true)
            {
                destinationUI.SetActive(false);
                //agent = largePayloadController.GetComponent<NavMeshAgent>();
                agent.speed = speedOfAgent;
                agent.destination = volcanoDest.transform.position;
                destinationWanted = false;
            }
    }

    public void AIBitMountain()
    {
        if (destinationWanted == true)
            {
                destinationUI.SetActive(false);
                //agent = largePayloadController.GetComponent<NavMeshAgent>();
                agent.speed = speedOfAgent;
                agent.destination = mountainDest.transform.position;
                destinationWanted = false;
            }
    }

    public void AIBitRainforest()
    {
        if (destinationWanted == true)
            {
                destinationUI.SetActive(false);
                //agent = largePayloadController.GetComponent<NavMeshAgent>();
                agent.speed = speedOfAgent;
                agent.destination = rainforestDest.transform.position;
                destinationWanted = false;
            }
    }

    public void AIBitMainDome()
    {
        if (destinationWanted == true)
            {
                destinationUI.SetActive(false);
                //agent = largePayloadController.GetComponent<NavMeshAgent>();
                agent.speed = speedOfAgent;
                agent.destination = mainDomeDest.transform.position;
                destinationWanted = false;
            }
    }
}
