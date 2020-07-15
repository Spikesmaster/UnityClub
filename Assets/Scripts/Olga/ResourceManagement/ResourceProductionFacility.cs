
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*
 * 
 */


    public class ResourceProductionFacility : MonoBehaviour
    {
    /// Public Properties
    public ResourcePool[] generatedResources;

    public bool autoGenerationIsOn;

    public void Start()
    {
    }

    public void Update()
    {
        if (autoGenerationIsOn)
        {
            foreach (var pool in generatedResources)
            {
                TriggerGenerateBehaviour(pool);
            }
        }

    }

    public void TriggerGenerateBehaviour(ResourcePool resourcePool)
    {
        //set a period to trigger
    }


    void GenerateResource(ResourcePool resourcePool)
    {
        //set here the value randomly each time based on the generationRate
        float thisValue = UnityEngine.Random.Range(resourcePool.minUnitSize, resourcePool.maxUnitSize);

        resourcePool.AddResources(thisValue);
    }

    //to be called by the drones when they take resources
    public void RemoveResource(ResourcePool resourcePool, float amount)
    {
        resourcePool.RemoveResources(amount);
    }
 
}
