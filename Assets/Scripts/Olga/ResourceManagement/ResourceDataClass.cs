using UnityEngine;
using System;

[Serializable]
public class ResourcePool
{

    public ResourceTypes resourceType;
    
    
    public float maximumPoolSize;
    public float currentPoolSize;


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
}

[Serializable]
public class ColonyResourceStorage : ResourcePool
{
    public bool autoConsumptionIsOn;
    public ConsumptionRate consumptionRate;
}
[Serializable]
public class NaturalResourceDeposit : ResourcePool
{
    public bool autoGenerationIsOn;
    public ConsumptionRate generationRate;
}

[Serializable]
public class OutpostMinedReservoir 
{
    /*
    public OutpostMinedReservoir ()
    {
        minedReservesPool.resourceType = naturalResourceArea.naturalResourceDeposit.resourceType;
    }
    */

    public NaturalResourceArea naturalResourceArea;
    public bool autoMineResources;
    public MiningRate generationRate;
    public ResourcePool minedReservesPool;


}

public enum ResourceTypes
{
    Minerals,
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

public enum MiningRate
{
    High,
    Mid,
    Low
}