
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*
 * 
 */


    public class NaturalResourceArea : MonoBehaviour
    {
    /// Public Properties

    //should be one 
    public NaturalResourceDeposit naturalResourceDeposit;

   public void Start()
    {
    }

    public void Update()
    {
         if (naturalResourceDeposit.autoGenerationIsOn)
                TriggerGenerateBehaviour(naturalResourceDeposit);
 
    }
    //here add code for recycling resources

    public void TriggerGenerateBehaviour(NaturalResourceDeposit resourcePool)
    {
        //set a behaviour according to the rate

    }

    //do the actual generation here
    void GenerateResource(ResourcePool resourcePool)
    {
        //set here the value randomly each time based on the generationRate
        float thisValue = UnityEngine.Random.Range(resourcePool.minUnitSize, resourcePool.maxUnitSize);
        resourcePool.AddResources(thisValue);
    }

    //to be called by the drones when they take resources
    public void YieldResource(float amount)
    {
        naturalResourceDeposit.RemoveResources(amount);
    }
 


}
