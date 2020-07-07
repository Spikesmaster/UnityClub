using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManagement : MonoBehaviour
{
    public float waterSupply, foodSupply, waterConsumption, foodConsumption;
    public float waterGeneration, foodGeneration;
    public float minEventTime, maxEventTime, nextEventTime;
    public Slider waterSlider, foodSlider;
    void Awake() 
    {
        UpdateValueSliders();
        nextEventTime = Random.Range(minEventTime, maxEventTime) + Time.time;
    }
    void Update() 
    {
        if (Time.time > nextEventTime)
        {
            int decision = Random.Range(0,2);
            if (decision == 0)
                {
                    waterSupply -= waterConsumption; // Takes water from the outpost (we still need to choose the time - Every minute? Two minutes?).
                    foodSupply -= foodConsumption; // Takes food from the outpost.
                }
            else
            {
                Debug.Log("Consume");
                waterSupply += waterGeneration;
                foodSupply += foodGeneration;
            }
            UpdateValueSliders();
            nextEventTime = Random.Range(minEventTime, maxEventTime) + Time.time;
        }
    }
    void UpdateValueSliders()
    {
        waterSlider.value = waterSupply; // Updates the value of the waterSupply on the visual slider on the UI.
        foodSlider.value = foodSupply; // Updates the value of the foodSupply on the visual slider on the UI.
    }

    public void ConsumeWater(float amountOfWater)
    {
        waterSupply -= amountOfWater;
        waterSlider.value = waterSupply; // Updates the value of the waterSupply on the visual slider on the UI.
    }
    public void ConsumeFood(float amountOfFood)
    {
        foodSupply -= amountOfFood;
        foodSlider.value = foodSupply; // Updates the value of the foodsupply on the visual slider on the UI.
    }
    
    public void AddWater(float amountOfWater)
    {
        waterSupply += amountOfWater;
        waterSlider.value = waterSupply; // Updates the value of the waterSupply on the visual slider on the UI.
    }

    public void AddFood(float amountOfFood)
    {
        foodSupply += amountOfFood;
        foodSlider.value = foodSupply; // Updates the value of the foodSupply on the visual slider on the UI.
    }
}