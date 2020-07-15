using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

    public class Worker : MonoBehaviour
    {
    /// Public Properties

    /// Serialized Fields for Editor
#pragma warning disable 0649
    [SerializeField]
    CarryingCapacity carryingCapacity;
    [SerializeField]
    Speed speed;
    [SerializeField]
    bool canBeCaptured;
#pragma warning restore 0649

    float baseSpeed;
    float baseHealth;

    ///  private Fields
    public bool isHeading;

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
        if (isHeading)
        {
            CheckForArrival();
        }
        }

        void OnDisable()
        {
        }


    ///  Public Methods
    public void HeadFor(IResourceFacility resourceFacility)
    {
        isHeading = true;
    }

    public void CheckForArrival()
    {
        ////if bleble
       // isHeading = false;
    }

    public void AskForInstructions()
    {
        //add code here to pop UI to tell the worker what to do
    }

    ///  Private Methods
    private void OnMouseDown()
    {
        WorkerSelectionManager.Instance.ReceiveFocus(this);
    }

    public enum CarryingCapacity
    {
        Low,
        High
    }

    enum Speed
    {
        High, 
        Low
    }
}


