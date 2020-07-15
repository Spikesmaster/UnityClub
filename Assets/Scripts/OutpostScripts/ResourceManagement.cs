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
    public GameObject warningTimer;
    void Awake() 
    {
        UpdateWaterUI();
        UpdateFoodUI();
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
                    ConsumeWater(waterConsumption); // Takes water from the outpost (we still need to choose the time - Every minute? Two minutes?).
                    ConsumeFood(foodConsumption); // Takes food from the outpost.
                }
            else
            {
                AddWater(waterGeneration);
                AddFood(foodGeneration);
            }

            nextEventTime = Random.Range(minEventTime, maxEventTime) + Time.time;
        }
    }

    public float ConsumeWater(float amountOfWater)
    {
        float waterToReturn = 0;
        if(waterSupply<amountOfWater){
            waterToReturn = waterSupply;
            waterSupply = minSupplies;
            warningTimer.SetActive(true);
        }else{
            waterToReturn = amountOfWater;
            waterSupply -= amountOfWater;
        }
        UpdateWaterUI();
        return waterToReturn;
    }
    public float ConsumeFood(float amountOfFood)
    {
        float foodToReturn = 0;
        if (foodSupply < amountOfFood)
        {
            foodToReturn = foodSupply;
            foodSupply = minSupplies;
            warningTimer.SetActive(true);
        }else{
            foodToReturn = amountOfFood;
            foodSupply -= amountOfFood;
        }
        UpdateFoodUI();
        return foodToReturn;
    }
    public void AddWater(float amountOfWater)
    {
        waterSupply += amountOfWater;
        if (waterSupply >= maxSupplies)
        {
            waterSupply = maxSupplies;
        }
        if(waterSupply>minSupplies&&foodSupply>minSupplies){
            warningTimer.SetActive(false);
        }
        UpdateWaterUI();
    }

    public void AddFood(float amountOfFood)
    {
        foodSupply += amountOfFood;
        if (foodSupply >= maxSupplies)
        {
            foodSupply = maxSupplies;
        }
        if(foodSupply>minSupplies&&waterSupply>minSupplies){
            warningTimer.SetActive(false);
        }
        UpdateFoodUI();
    }

    void UpdateWaterUI()
    {
        waterSlider.value = waterSupply; // Updates the value of the waterSupply on the visual slider on the UI.
        int aux = (int) waterSupply;
        waterNumber.text = aux.ToString("00");
    }

    void UpdateFoodUI()
    {
        foodSlider.value = foodSupply; // Updates the value of the foodSupply on the visual slider on the UI.
        int aux = (int)foodSupply;
        foodNumber.text = aux.ToString("00");
    }
}