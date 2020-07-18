using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OutpostColonyModification : MonoBehaviour
{
    /// Public Properties
    ColonyResourceManager colonyResourceManager;
    ResourceRetrievalOutpost resourceRetrievalOutpost;
    /// Serialized Fields for Editor
#pragma warning disable 0649

#pragma warning restore 0649


    ///  private Fields


    ///  Unity CallBacks Methods
    void Awake()
    {
        resourceRetrievalOutpost = GetComponent<ResourceRetrievalOutpost>();
        colonyResourceManager = GetComponent<ColonyResourceManager>();
    }

    void OnEnable()
    {
    }

    void Start()
    {
    }

    void Update()
    {

    }

    void OnDisable()
    {
    }


    ///  Public Methods

    //CountMiningReservoirAsColonyResourceStorageToo();

    ///  Private Methods
    void CountMiningReservoirAsColonyResourceStorageToo()
    {
        //if the storage is empty, can you draw from mined reserves?
        foreach (var storagepool in colonyResourceManager.resourceStoragePools)
        {
            foreach (var minepool in resourceRetrievalOutpost.outpostMinedReservoirs)
            {

                if (minepool.minedReservesPool.resourceType == storagepool.resourceType)
                {
                    storagepool.currentPoolSize = minepool.minedReservesPool.currentPoolSize;
                }

            }
        }

    }

    void SyncMiningPoolWithResourceStorage()
    {
        //this is called when the mine reservoir gets a new incoming load or ships off a shipment
    }
    void SyncResourceStorageWithMinePool()
    {
        //this is called when the Colony consumes Mine reservoir
    }
}

