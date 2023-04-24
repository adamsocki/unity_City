using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;   

public class TimeManager : MonoBehaviour
{

    // Time of day in your game (0 - 24 hours)
    public float timeOfDay;

    // Time scale for how quickly time passes in your game (1 = real-time, higher numbers = faster)
    public float timeScale = 1f;


    

    public void UpdateTimeManager()
    {
        UpdateTimeOfDay();
    }

    public void UpdateTimeOfDay()
    {
        timeOfDay += Time.deltaTime * timeScale / 3600f;
        if (timeOfDay >= 24f)
        {
            timeOfDay -= 24f;
        }

        // Format the time as HH:MM:SS
        string formattedTime = TimeSpan.FromHours(timeOfDay).ToString(@"hh\:mm\:ss");
        //Debug.Log("Time of Day: " + formattedTime);
    }

    public string GetFormattedTime()
    {
        return TimeSpan.FromHours(timeOfDay).ToString(@"hh\:mm\:ss");
    }

}
