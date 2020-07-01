using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManagement : MonoBehaviour
{
    public float waterSupply, foodSupply, waterConsumption, foodConsumption;
    public Slider waterSlider, foodSlider;
    void Update() 
    {
        waterSupply -= waterConsumption * Time.deltaTime; // Takes water from the outpost (we still need to choose the time - Every minute? Two minutes?).
        foodSupply -= foodConsumption * Time.deltaTime; // Takes food from the outpost.
        waterSlider.value = waterSupply; // Updates the value of the waterSupply on the visual slider on the UI.
        foodSlider.value = foodSupply; // Updates the value of the foodSupply on the visual slider on the UI.
    }
}