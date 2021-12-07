using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SimplePlayerStats
{

    public string displayname;
    public int highscore;
    public int xp;
    public long updatedOn;
    public long createdOn;

    //Constructor
    public SimplePlayerStats()
    {

    }

    public SimplePlayerStats(string displayname, int highscore, int xp = 0)
    {
        this.displayname = displayname;
        this.highscore = highscore;
        this.xp = xp;

        var timestamp = this.GetTimeUnix();
        this.updatedOn = timestamp;
        this.createdOn = timestamp;
    }

    public long GetTimeUnix()
    {
        return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
    }

    public string SimplePlayerStatsToJson()
    {
        return JsonUtility.ToJson(this);
    }
}
