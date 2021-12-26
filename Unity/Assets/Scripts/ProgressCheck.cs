using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressCheck : MonoBehaviour
{
    public SpeedRunManager speedrun;

    public bool cpuIn = false;
    public bool ramIn = false;
    public bool ssdIn = false;
    public bool fanIn = false;
    public bool mBIn = false;
    public bool gpuIn = false;
    public bool wifiIn = false;
    public bool psuIn = false;
    public bool gpIn = false;
    public int screws = 0;

    private void Update()
    {
        ProgressChecker();
    }
    private void ProgressChecker()
    {
        if ((cpuIn && ramIn && ssdIn &&
            fanIn && mBIn && gpuIn &&
            wifiIn &&psuIn && gpIn)
             && screws >= 13)
        {

           speedrun.GetComponent<SpeedRunManager>().GameEnd();
        }
    }
}
