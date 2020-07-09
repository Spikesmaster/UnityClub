using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

    public class DroneMoonResponse : MonoBehaviour
    {
    /// Public Properties


    /// Serialized Fields for Editor
#pragma warning disable 0649
    [SerializeField]
    float baseSpeed;
    [SerializeField]
    float speedBuffMultiplier;
    [SerializeField]
    float speedDebuffMultiplier;
#pragma warning restore 0649


    ///  private Fields
    Moon[] moons;
    float currentSpeed;
    bool canBeCaptured;
        ///  Unity CallBacks Methods
        void Awake()
        {
        moons = FindObjectsOfType<Moon>();
        }

        void OnEnable()
        {
        foreach (var moon in moons)
        {
            moon.MoonRiseEvent += MoonRiseResponse;
            moon.MoonSetEvent += MoonSetResponse;
        }
        }

        void Start()
        {
        currentSpeed = baseSpeed;
        canBeCaptured = true;
        }

        void Update()
        {
        }

        void OnDisable()
        {
        foreach (var moon in moons)
        {
            moon.MoonRiseEvent -= MoonRiseResponse;
            moon.MoonSetEvent -= MoonSetResponse;
        }
    }


        ///  Public Methods



        ///  Private Methods
        void MoonRiseResponse(MoonTypes moonType)
    {
        switch (moonType)
        {
            case MoonTypes.blueMoon:
                ChangeSpeed(speedBuffMultiplier);
                BecomeInvincible();
                break;

            case MoonTypes.pinkMoon:
                ChangeSpeed(speedDebuffMultiplier);
                break;

                //since I want nothing, I can omitt this:
            case MoonTypes.purpleMoon:
                //do nothing
                break;
        }
    }

    void MoonSetResponse(MoonTypes moonType)
    {
        //I m resetting the full state in all cases, so I don't differentiate here.
        ResetState();
    }




    void ChangeSpeed(float multiplier)
    {
        currentSpeed = baseSpeed * multiplier;
    }

    void ResetSpeed()
    {
        currentSpeed = baseSpeed;
    }


    void BecomeInvincible()
    {
        canBeCaptured = false;
    }

    void ResetInvincible()
    {
        canBeCaptured = true;
    }


    void ResetState()
    {
        ResetInvincible();
        ResetSpeed();
    }
    }
