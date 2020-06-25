using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronePayloadController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject droneDepotUI;
    public GameObject largePayloadController, smallPayloadController;
    void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        droneDepotUI.SetActive(true);
    }

    public void LargePayload()
    {
        //droneDepotUI.SetActive(false);
        largePayloadController.GetComponent<DroneTravel>().enabled = true;
    }

    public void SmallPayload()
    {
        //droneDepotUI.SetActive(false);
        smallPayloadController.GetComponent<DroneTravel>().enabled = true;
    }
    
}
