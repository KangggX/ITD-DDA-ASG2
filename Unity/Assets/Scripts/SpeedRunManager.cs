using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class SpeedRunManager : MonoBehaviour
{
    public bool speedRun = true;

    //Timer
    public bool timeActive = false;
    public float currentTime;
    public TMP_Text currentTimeText;
    public int points = 0;
    public GameObject player;

    //Update Database
    public bool isUpdated = false;

    //Firebase
    public AuthManager authMgr;
    public SimpleFirebaseManager fbMgr;

    private void Start()
    {
        StartTimer();
        currentTime = 0;
    }

    private void Update()
    {
        //InGameTimer();
        if (timeActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            currentTimeText.text = "Time taken " + time.Minutes.ToString() + ":" + time.Seconds.ToString();
        }
        Debug.Log(timeActive);
    }

    public void StartTimer()
    {
        timeActive = true;
    }

    public void GameEnd()
    {
        print("wdawd");
        timeActive = false;
        if (isUpdated == false)
        {
            print("end");
            SceneManager.LoadScene("NewMainMenu");
            UpdatePlayerStats((int)currentTime);
            
            isUpdated = true;
            
        }
    }

    public void UpdatePlayerStats(int time)
    {
        fbMgr.UpdatePlayerStats(authMgr.GetCurrentUser().UserId, authMgr.GetCurrentUserDisplayName(), time);
    }
}
