using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneTravel : MonoBehaviour
{
    public Transform droneSpawn;
    public GameObject dronePrefab;
    public GameObject destination;
    private NavMeshAgent agent;
    public float speedOfAgent;
    public float payloadDropTime;
    void Start()
    {
        //startingPosition =  gameObject.transform.position;//, gameObject.transform.rotation);
        //Instantiate(dronePrefab, droneSpawn.position, droneSpawn.localRotation);
        //dronePrefab.GetComponent<NavMeshAgent>().Warp(droneSpawn.position);
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speedOfAgent;
        agent.destination = destination.transform.position;
        
        //agent.destination = startingPosition.position;
    }

    
    void Update()
    {
        
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Invoke("PayloadDrop", payloadDropTime);
        }
    }

    void PayloadDrop()
    {
        agent.destination = droneSpawn.transform.position;
    }
}
