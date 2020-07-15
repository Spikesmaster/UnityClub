using System;
using UnityEngine;

public class ResourceManagementSample : MonoBehaviour
{
    
    //like this
    public ResourcePool[] resourcePools;

    //OR
    //like this
     ResourcePool mainResource;
     ResourcePool secondaryResource;

    public bool autoConsumptionIsOn;


    public void Update()
    {
        if (autoConsumptionIsOn)
        {
            foreach (var pool in resourcePools)
            {
                TriggerConsumptionEvent(pool);
            }
            //OR
            /*
            TriggerConsumptionEvent(mainResource);
            TriggerConsumptionEvent(secondaryResource);
        */

        }
        
    }

    void TriggerConsumptionEvent(ResourcePool resourcePool)
    {
///add code here 
/// calculate values based on resourcepool ConsumptionRate
    }

    //to be called by events when they cost resources + by TriggerConsumptionEvent 
    public void ConsumeResource(ResourcePool resourceType, float amount)
    {
        resourceType.RemoveResources(amount);
    }

    //to be called by the drones when they bring resources
    public void AddResource(ResourcePool resourceType, float amount)
    {
        resourceType.AddResources(amount);
    }

}
