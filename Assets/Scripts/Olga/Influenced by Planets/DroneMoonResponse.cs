using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

    public class DroneMoonResponse : MoonInfluencedBase
    {
    /// Public Properties
    public event Action<float> ValueChangedEvent;

    /// Serialized Fields for Editor
#pragma warning disable 0649
    [SerializeField]
    float baseSpeed;
    [SerializeField]
    float speedBuffMultiplier;
    [SerializeField]
    float speedDebuffMultiplier;

    float currentSpeed;
    bool canBeCaptured;
#pragma warning restore 0649


    ///  private Fields


    ///  Unity CallBacks Methods

    void Start()
        {
        currentSpeed = baseSpeed;
        canBeCaptured = true;
        }

        void Update()
        {
        }

        ///  Public Methods
       public override void MoonRiseResponse(MoonTypes moonType)
    {
        switch (moonType)
        {
            case MoonTypes.blueMoon:
                ChangeSpeed(speedBuffMultiplier);
                ValueChangedEvent(currentSpeed);
                BecomeInvincible();
                break;

            case MoonTypes.pinkMoon:
                ChangeSpeed(speedDebuffMultiplier);
                ValueChangedEvent(currentSpeed);
                break;

                //since I want nothing, I can omitt this:
            case MoonTypes.purpleMoon:
                //do nothing
                break;
        }
    }

    public override void MoonSetResponse(MoonTypes moonType)
    {
        //I m resetting the full state in all cases, so I don't differentiate here.
        ResetState();
    }


    ///  Private Methods

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
