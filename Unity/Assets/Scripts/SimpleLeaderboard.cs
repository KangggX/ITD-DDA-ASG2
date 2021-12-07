using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SimpleLeaderboard
{
    public string displayname;
    public int highscore;
    public long updatedOn;
    
    //Constructor
    public SimpleLeaderboard()
    {

    }

    public SimpleLeaderboard(string displayname, int highscore)
    {
        this.displayname = displayname;
        this.highscore = highscore;
        this.updatedOn = GetTimeUnix();
    }

    public long GetTimeUnix()
    {
        return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
    }
    public string SimpleLeaderboardToJson()
    {
        return JsonUtility.ToJson(this);
    }
}
