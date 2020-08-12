using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMoonResponseBridge : MonoBehaviour
{
    DroneManager droneManager;
    DroneMoonResponse droneMoonResponse;

    private void Awake()
    {
        droneManager = GetComponent<DroneManager>();
        droneMoonResponse = GetComponent<DroneMoonResponse>();
    }

    private void OnEnable()
    {
        droneMoonResponse.ValueChangedEvent += PassValueToScript;
    }

    private void OnDisable()
    {
        droneMoonResponse.ValueChangedEvent -= PassValueToScript;
    }


    void PassValueToScript(float value)
    {
        droneManager.droneSpeed = value;
    }
}
