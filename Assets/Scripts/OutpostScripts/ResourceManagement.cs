using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManagement : MonoBehaviour
{
    public float waterSupply;
    public float foodSupply;
    public float waterConsumption;
    public float foodConsumption;
    public Slider waterSlider;
    public Slider foodSlider;
    void Update() 
    {
        waterSupply -= waterConsumption * Time.deltaTime;
        foodSupply -= foodConsumption * Time.deltaTime;
        Debug.Log("Water supplies: " + waterSupply);
        Debug.Log("Food supplies: " + foodSupply);
        waterSlider.value = waterSupply;
        foodSlider.value = foodSupply;
    }


    
}
