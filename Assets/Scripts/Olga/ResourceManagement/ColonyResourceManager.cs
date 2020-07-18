using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*
 * 
 */

    public class ColonyResourceManager : MonoBehaviour
    {
    /// Public Properties
    public ColonyResourceStorage[] resourceStoragePools;

    /// Serialized Fields for Editor
#pragma warning disable 0649

#pragma warning restore 0649


    ///  private Fields


    ///  Unity CallBacks Methods
    void Awake()
        {
        }

        void OnEnable()
        {
        }

        void Start()
        {
        }

        void Update()
        {

        {
            foreach (var pool in resourceStoragePools)
            {
                if (pool.autoConsumptionIsOn)
                ///add code here 
                TriggerConsumptionEvent(pool);
            }
        }

        }

        void OnDisable()
        {

        }


    ///  Public Methods
    void TriggerConsumptionEvent(ResourcePool resourcePool)
    {
        ///add code here 
        /// calculate values based on resourcepool ConsumptionRate
    }

    //to be called by events when they cost resources + by TriggerConsumptionEvent 
    void ConsumeResource(ResourcePool resourceType, float amount)
    {
        resourceType.RemoveResources(amount);
    }

    ///  Private Methods

}
