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
    public float smallDroneSpeed, largeDroneSpeed;
    // public float payloadDropTime;
    private bool destinationWanted = false;
    public GameObject largePayloadController, smallPayloadController;
    private bool largeDroneChosen = true;

    public void ResourceSelection()
    {
        droneDepotUI.SetActive(false);
        destinationUI.SetActive(true);
        destinationWanted = true;
    }

    
    public void LargeDrone()
    {
        if (destinationWanted == false)
        {
            Debug.Log("OnMouseDown");
            droneDepotUI.SetActive(true);
            regionName.text = "Slow but strong"; //Since we are now touching the drones, the area doesn't make sense anymore.
            largeDroneChosen = true;    
        }
    }

    public void SmallDrone()
    {
        if (destinationWanted == false)
        {
            Debug.Log("OnMouseDown");
            droneDepotUI.SetActive(true);
            regionName.text = "Fast but weak"; //Since we are now touching the drones, the area doesn't make sense anymore.
            largeDroneChosen = false;   
        }
    }

    public void AIBitVolcano()
    {
        if (destinationWanted == true)
            {
                destinationUI.SetActive(false);
                if (largeDroneChosen == true)
                {
                    agent = largePayloadController.GetComponent<NavMeshAgent>();
                    agent.speed = largeDroneSpeed;
                    agent.destination = volcanoDest.transform.position;
                    destinationWanted = false;
                }

                if (largeDroneChosen == false)
                {
                    agent = smallPayloadController.GetComponent<NavMeshAgent>();
                    agent.speed = smallDroneSpeed;
                    agent.destination = volcanoDest.transform.position;
                    destinationWanted = false;
                }
            }
    }

    public void AIBitMountain()
    {
        if (destinationWanted == true)
            {
                destinationUI.SetActive(false);
                if (largeDroneChosen == true)
                {
                    agent = largePayloadController.GetComponent<NavMeshAgent>();
                    agent.speed = largeDroneSpeed;
                    agent.destination = mountainDest.transform.position;
                    destinationWanted = false;
                }

                if (largeDroneChosen == false)
                {
                    agent = smallPayloadController.GetComponent<NavMeshAgent>();
                    agent.speed = smallDroneSpeed;
                    agent.destination = mountainDest.transform.position;
                    destinationWanted = false;
                }
            }
    }

    public void AIBitRainforest()
    {
        if (destinationWanted == true)
            {
                destinationUI.SetActive(false);
                if (largeDroneChosen == true)
                {
                    agent = largePayloadController.GetComponent<NavMeshAgent>();
                    agent.speed = largeDroneSpeed;
                    agent.destination = rainforestDest.transform.position;
                    destinationWanted = false;
                }

                if (largeDroneChosen == false)
                {
                    agent = smallPayloadController.GetComponent<NavMeshAgent>();
                    agent.speed = smallDroneSpeed;
                    agent.destination = rainforestDest.transform.position;
                    destinationWanted = false;
                }
            }
    }

    public void AIBitMainDome()
    {
        if (destinationWanted == true)
            {
                destinationUI.SetActive(false);
                if (largeDroneChosen == true)
                {
                    agent = largePayloadController.GetComponent<NavMeshAgent>();
                    agent.speed = largeDroneSpeed;
                    agent.destination = mainDomeDest.transform.position;
                    destinationWanted = false;
                }

                if (largeDroneChosen == false)
                {
                    agent = smallPayloadController.GetComponent<NavMeshAgent>();
                    agent.speed = smallDroneSpeed;
                    agent.destination = mainDomeDest.transform.position;
                    destinationWanted = false;
                }
            }
    }
}
