using UnityEngine;
using TMPro;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class DronePayloadController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject droneDepotUI;
    public TextMeshProUGUI regionName;
    public GameObject destinationUI;
    public GameObject volcanoDest, mountainDest, mainDomeDest, rainforestDest;
    private NavMeshAgent agent;
    public float speedOfAgent;
    // public float payloadDropTime;
    private bool destinationWanted = false;
    public GameObject largePayloadController;
    
    // void Start()
    // {
    //     EventTrigger trigger = GetComponent<EventTrigger>();
    //     EventTrigger.Entry entry = new EventTrigger.Entry();
    //     entry.eventID = EventTriggerType.PointerDown;
    //     entry.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); });
    //     trigger.triggers.Add();
    // }    
    void OnMouseDown()
    {
        if (destinationWanted == false)
        {
            if (gameObject.CompareTag("LargeDrone"))
            {
                Debug.Log("OnMouseDown");
                droneDepotUI.SetActive(true);
                regionName.text = "Slow but strong"; //Since we are now touching the drones, the area doesn't make sense anymore.
            }

            if (gameObject.CompareTag("SmallDrone"))
            {
                droneDepotUI.SetActive(true);
                regionName.text = "Fast but weak";
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
    

    // public void OnPointerDownDelegate(PointerEventData data)
    // {
    //     Debug.Log("OnPointerDownDelegate called.");
    // }

    
    // void Update() 
    // {
    //     Debug.Log("Destination wanted: " + destinationWanted);
    //     // if (agent.remainingDistance <= agent.stoppingDistance)
    //     // {
    //     //     destinationWanted = false;
    //     // }
    //     agent = largePayloadController.GetComponent<NavMeshAgent>();
    // }

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
                agent = largePayloadController.GetComponent<NavMeshAgent>();
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
                agent = largePayloadController.GetComponent<NavMeshAgent>();
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
                agent = largePayloadController.GetComponent<NavMeshAgent>();
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
                agent = largePayloadController.GetComponent<NavMeshAgent>();
                agent.speed = speedOfAgent;
                agent.destination = mainDomeDest.transform.position;
                destinationWanted = false;
            }
    }
}
