using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*
 * 
 */


    public class WorkerSelectionManager : MonoBehaviour
    {
    /// Public Properties

    public static WorkerSelectionManager Instance;

    /// Serialized Fields for Editor
#pragma warning disable 0649
    [SerializeField]
    KeyCode selectDestinationKeyCode;

#pragma warning restore 0649


    ///  private Fields
     Worker previousWorker;
    [SerializeField]
      Worker currentWorker;

    ///  Unity CallBacks Methods
    void Awake()
        {
        Instance = this;
        }

        void OnEnable()
        {
        }

        void Start()
        {
        }

        void Update()
        {
        if (currentWorker != null)
        {
            if (Input.GetKeyDown(selectDestinationKeyCode))
            {
                if (!currentWorker.isHeading)
                {
                    SelectDestination();
                    Debug.Log("Selected Destination for worker");
                }
                else
                {
                    Debug.Log("Worker already has destination. Cannot change midway!");
                }
            }

        }
        }

        void OnDisable()
        {
        }


        ///  Public Methods
        public  void ReceiveFocus(Worker worker)
    {
        if (currentWorker != worker)
        { 
        previousWorker = currentWorker;
        currentWorker = worker;
        }
    }


    ///  Private Methods
    void SelectDestination()
    {
        //pop up UI 
        //click on location
        //declare as destination 
        //tell worker to go
    }



    }
