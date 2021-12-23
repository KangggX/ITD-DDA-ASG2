using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SimplePlayerStats
{

    public string displayname;
    public int fastestTime;
    public int xp;
    public long updatedOn;
    public long createdOn;

    //Constructor
    public SimplePlayerStats()
    {

    }

    public SimplePlayerStats(string displayname, int fastestTime, int xp = 0)
    {
        this.displayname = displayname;
        this.fastestTime = fastestTime;
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
