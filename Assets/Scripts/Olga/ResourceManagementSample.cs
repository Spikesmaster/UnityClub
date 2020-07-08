using System;
using UnityEngine;

public class ResourceManagementSample : MonoBehaviour
{
    
    public ResourcePool mainResource;
    public ResourcePool secondaryResource;

    public bool autoConsumptionIsOn;

    public void Start()
    {
    }

    public void Update()
    {
        if (autoConsumptionIsOn)
        {
            TriggerConsumptionEvent(mainResource);
            TriggerConsumptionEvent(secondaryResource);
        }
        
    }

    void TriggerConsumptionEvent(ResourcePool resourcePool)
    {
///add code here
///
    }

    //to be called by the drones
    public void ConsumeResource(ResourcePool resourceType, float amount)
    {
        resourceType.ConsumeResources(amount);
    }
    public void AddResource(ResourcePool resourceType, float amount)
    {
        resourceType.AddResources(amount);
    }

}

[Serializable]
public class ResourcePool
{
    public ResourceTypes resourceType;
    public float maximumPoolSize;
    public float currentPoolSize;

    public float averageConsumptionFrequency;
   
    public float minConsumptionUnitSize = 10;
    public float maxConsumptionUnitSize = 20;

    public void AddResources(float value)
    {
        currentPoolSize += value;
        currentPoolSize = Mathf.Ceil(maximumPoolSize);
    }

    public void ConsumeResources(float value)
    {
        currentPoolSize -= value;
        currentPoolSize = Mathf.Floor(0);
    }

    public void ConsumptionBehaviour()
    {
        float thisConsumption = UnityEngine.Random.Range(minConsumptionUnitSize, maxConsumptionUnitSize);
        ConsumeResources(thisConsumption);
    }
}


public enum ResourceTypes
{
    Food,
    Water
}
