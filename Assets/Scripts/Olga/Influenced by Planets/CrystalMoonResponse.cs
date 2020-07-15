using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
/*
 * 
 */

    public class CrystalMoonResponse : MoonInfluencedBase
    {
        /// Public Properties


        /// Serialized Fields for Editor
#pragma warning disable 0649

#pragma warning restore 0649


        ///  private Fields


        ///  Unity CallBacks Methods

        void Start()
        {
        }

        void Update()
        {
        }


    public override void MoonRiseResponse(MoonTypes moonType)
    {
        //raise resource output
    }

    public override void MoonSetResponse(MoonTypes moonType)
    {
        //restore resource output to normal
    }

    ///  Public Methods



    ///  Private Methods

}
