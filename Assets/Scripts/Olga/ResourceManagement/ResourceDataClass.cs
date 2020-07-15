using UnityEngine;
using System;

[Serializable]
public class ResourcePool
{

    public ResourceTypes resourceType;
    
    
    public float maximumPoolSize;
    public float currentPoolSize;

    public ConsumptionRate consumptionRate;
    public GenerationRate generationRate;
    //make a dictionary of ConsumptionRate to actual values

    [HideInInspector]
    public float minUnitSize;
    [HideInInspector]
    public float maxUnitSize;

    public void AddResources(float value)
    {
        currentPoolSize += value;
        currentPoolSize = Mathf.Ceil(maximumPoolSize);
    }

    public void RemoveResources(float value)
    {
        currentPoolSize -= value;
        currentPoolSize = Mathf.Floor(0);
    }

    public void ConsumptionBehaviour()
    {
        float thisConsumption = UnityEngine.Random.Range(minUnitSize, maxUnitSize);
        RemoveResources(thisConsumption);
    }


}


public enum ResourceTypes
{
    Food,
    Water
}


public enum ConsumptionRate
{
    High,
    Mid,
    Low
}

public enum GenerationRate
{
    High,
    Mid,
    Low
}