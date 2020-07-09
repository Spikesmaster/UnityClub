using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{

    public int currentDay;//starts at 0 and marks the current day from the beggining
    public float dayDuration;//number of seconds that each day lasts
    float timeForNextDay;
    public bool isDaylight;//true if it's during the day and false if it's night
    public float dayLightDuration;//time in seconds when we changes isDaylight from true to false
    float timeForDayLightChange;
    public int weatherCycle;//after how many days  to enter rain season
    int nextRainDay;
    public List<GameObject> weatherOutposts = new List<GameObject>();
    public float waterAmmount;
    // Start is called before the first frame update
    void Start()
    {
        currentDay = 0;
        isDaylight = true;
        timeForNextDay = Time.time+dayDuration;
        timeForDayLightChange = Time.time+dayLightDuration;
        nextRainDay = weatherCycle;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>timeForNextDay){
            currentDay++;
            timeForNextDay = Time.time+dayDuration;
        }

        if(Time.time>timeForDayLightChange){
            isDaylight = !isDaylight;
            timeForDayLightChange = Time.time+dayLightDuration;
        }

        if(currentDay >= nextRainDay){
            foreach(GameObject outpost in weatherOutposts){
                outpost.GetComponent<ResourceManagement>().AddWater(waterAmmount);
            }
            nextRainDay += weatherCycle;
        }

    }
}
