using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    bool timeActive = false;
    float currentTime;
    public TMP_Text currentTimeText;
    public int points = 0;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = "Time taken "+time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    public void StartTimer()
    {
        timeActive = true;
    }

    public void StopTimer()
    {
        timeActive = false;
        if (currentTime < 60)
        {
            points += 1000;
        }
        if (currentTime >= 60 && currentTime < 65)
        {
            points += 900;
        }
        if (currentTime >= 65 && currentTime < 70)
        {
            points += 800;
        }
        if (currentTime >= 70 && currentTime < 75)
        {
            points += 700;
        }
        if (currentTime >= 75 && currentTime < 80)
        {
            points += 600;
        }
        if (currentTime >= 80 && currentTime < 85)
        {
            points += 500;
        }
        if (currentTime >= 85 && currentTime < 90)
        {
            points += 400;
        }
        if (currentTime >= 90 && currentTime < 95)
        {
            points += 300;
        }
        if (currentTime >= 95 && currentTime < 100)
        {
            points += 200;
        }
        if (currentTime >= 100)
        {
            points += 100;
        }
    }
}
