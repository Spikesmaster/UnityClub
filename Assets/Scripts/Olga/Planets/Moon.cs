using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum MoonTypes
{
    blueMoon,
    purpleMoon,
    pinkMoon
}

    public class Moon : Planet
    {


    /// Public Properties
    public event Action<MoonTypes> MoonRiseEvent;
    public event Action<MoonTypes> MoonSetEvent;

        /// Serialized Fields for Editor
#pragma warning disable 0649
    [SerializeField]
    MoonTypes moonType;
    [SerializeField]
    GameObject moonRiseCollisionZone;
    [SerializeField]
    GameObject moonSetCollisionZone;

#pragma warning restore 0649


    ///  Public Methods

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == moonRiseCollisionZone)
        {
            MoonRiseEvent?.Invoke(moonType);
            Debug.Log("Moon " + moonType + " rose.");
        }
        else if (other.gameObject == moonSetCollisionZone)
        {
            MoonSetEvent?.Invoke(moonType);
            Debug.Log("Moon " + moonType + " set.");
        }
    }

   

    ///  Private Methods

}


