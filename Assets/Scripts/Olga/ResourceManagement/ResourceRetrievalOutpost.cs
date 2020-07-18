using System;
using UnityEngine;

public class ResourceRetrievalOutpost: MonoBehaviour
{
    public OutpostMinedReservoir[] outpostMinedReservoirs;

    private void Awake()
    {
        foreach (var pool in outpostMinedReservoirs)
        {
            pool.minedReservesPool.resourceType = pool.naturalResourceArea.naturalResourceDeposit.resourceType;
        }
    }

    public void Update()
    {
            foreach (var pool in outpostMinedReservoirs)
            {
            if (pool.autoMineResources)
            {
                ///add code here to mine resources
            }

        }

    }


    //private

    void MineResources(NaturalResourceArea deposit, float rate)
    {
        float value = default;
        //calculate value based on rate
        deposit.YieldResource(value);

    }


    //public
    //to be called by the drones when they take resources
    public void RemoveResource(ResourcePool resourcePool, float amount)
    {
        resourcePool.RemoveResources(amount);
    }

}

