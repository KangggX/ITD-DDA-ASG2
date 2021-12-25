using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class SimplePlayerStatsManager : MonoBehaviour
{

    public TMP_Text playerXP;
    public TMP_Text playerName;
    public TMP_Text highscore;
    public TMP_Text lastPlayed;
    public GameObject confirmCanvas;
   
    public SimpleFirebaseManager fbMgr;
    public AuthManager auth;
    [Header ("Final Scene")]
    public static int currentPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        confirmCanvas.gameObject.SetActive(false);

        //Retrieve current logged in user's uuid
        //Update UI
        UpdatePlayerStats(auth.GetCurrentUser().UserId);
    }
    private void Update()
    {
        
    }

    public void backToMenu()
    {
        AudioClipManager.PlaySound("button");
        SceneManager.LoadScene(1);
    }
    public async void UpdatePlayerStats(string uuid)
    {
        SimplePlayerStats playerStats = await fbMgr.GetPlayerStats(uuid);
        
        if(playerStats != null)
        {
            highscore.text = playerStats.fastestTime.ToString();
            lastPlayed.text = UnixToDateTime(playerStats.updatedOn);
            playerName.text = auth.GetCurrentUserDisplayName();
        }
        else
        {
            ResetStatsUI();
        }
        playerName.text = auth.GetCurrentUserDisplayName();

    }

    public void ResetStatsUI()
    {
        playerXP.text = "0 XP";
        highscore.text = "0";
        lastPlayed.text = "None";
    }

    public void ConfirmDeletePlayerStats()
    {
        fbMgr.DeletePlayerStats(auth.GetCurrentUser().UserId);

        //Refresh player stats on screen
        ResetStatsUI();

        AudioClipManager.PlaySound("button");
        confirmCanvas.gameObject.SetActive(false);
    }

    public void DontConfirmDeletePlayerStats()
    {
        AudioClipManager.PlaySound("button");
        confirmCanvas.gameObject.SetActive(false);
    }
    public void DeletePlayerStats()
    {
        AudioClipManager.PlaySound("button");
        confirmCanvas.gameObject.SetActive(true);
    }

    public string UnixToDateTime(long timestamp)
    {
        //no. of seconds from 1/1/1970
        DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(timestamp);
        //Convert to current time format
        DateTime dateTime = dateTimeOffset.LocalDateTime;

        return dateTime.ToString("dd MMM yyyy");
    }

    public void MainMenu()
    {
        AudioClipManager.PlaySound("button");
        SceneManager.LoadScene(1);
    }
    
}
