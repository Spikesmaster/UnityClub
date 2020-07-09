using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceManagement : MonoBehaviour
{
    public float waterSupply, foodSupply, waterConsumption, foodConsumption;
    public float waterGeneration, foodGeneration;
    public float minEventTime, maxEventTime, nextEventTime;
    public Slider waterSlider, foodSlider;
    public float maxSupplies, minSupplies;
    public TextMeshProUGUI foodNumber, waterNumber;
    void Awake() 
    {
        UpdateAllUI();
        nextEventTime = Random.Range(minEventTime, maxEventTime) + Time.time;
    }
    void Update() 
    {
        if (waterSupply >= maxSupplies)
        {
            waterSupply = maxSupplies;
        }
        if (foodSupply >= maxSupplies)
        {
            foodSupply = maxSupplies;
        }
        if (waterSupply <= minSupplies)
        {
            waterSupply = minSupplies;
        }
        if (foodSupply <= minSupplies)
        {
            foodSupply = minSupplies;
        }

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
            UpdateAllUI();
            nextEventTime = Random.Range(minEventTime, maxEventTime) + Time.time;
        }
    }
    void UpdateAllUI()
    {
        waterSlider.value = waterSupply; // Updates the value of the waterSupply on the visual slider on the UI.
        foodSlider.value = foodSupply; // Updates the value of the foodSupply on the visual slider on the UI.
        waterNumber.text = waterSupply.ToString("00");
        foodNumber.text = foodSupply.ToString("00");
    }
    public void ConsumeWater(float amountOfWater)
    {
        waterSupply -= amountOfWater;
        UpdateWaterUI();  
    }
    public void ConsumeFood(float amountOfFood)
    {
        foodSupply -= amountOfFood;
        UpdateFoodUI();
    }
    public void AddWater(float amountOfWater)
    {
        waterSupply += amountOfWater;
        UpdateWaterUI();
    }

    public void AddFood(float amountOfFood)
    {
        foodSupply += amountOfFood;
        UpdateFoodUI();
    }

    void UpdateWaterUI()
    {
        waterSlider.value = waterSupply; // Updates the value of the waterSupply on the visual slider on the UI.
        waterNumber.text = waterSupply.ToString("00");
    }

    void UpdateFoodUI()
    {
        foodSlider.value = foodSupply; // Updates the value of the foodSupply on the visual slider on the UI.
        foodNumber.text = foodSupply.ToString("00");
    }
}