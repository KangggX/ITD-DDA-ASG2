using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRunManager : MonoBehaviour
{
    int screw;
    public bool itemCheck;
    bool gameStart = false;

    public int timer;
    public int counter;

    public bool speedRun = true;

    bool cpu = false;
    bool gpu = false;
    bool ssd = false;
    bool ram = false;
    bool fan = false;
    bool psu = false;
    bool cpufan = false;
    bool motherboard = false;
    bool screwed = false;

    private void Start()
    {
        screw = 0;
    }

    private void Update()
    {
        InGameTimer();
    }

    private void InGameTimer()
    {
        if (gameStart == true)
        {
        counter = counter + 1;
        }

        if (counter >= 200)
        {
            timer += 1;
            counter = 0;
        }
    }

    public void Screwed()
    {
        screw = screw + 1;
    }
    public void CPU()
    {
        cpu = true;
    }
    public void MotherBoard()
    {
        motherboard = true;
    }
    public void SSD()
    {
        ssd = true;
    }
    public void GPU()
    {
        gpu = true;
    }
    public void PSU()
    {
        psu = true;
    }public void RAM()
    {
        ram = true;
    }
    public void CPUFan()
    {
        cpufan = true;
    }
    public void Fan()
    {
        fan = true;
    }

    public void InGameCheck()
    {
        gameStart = true;
    }
    public void AllInstalled()
    {
        if(screw >= 8)
        {
            screwed = true;
        }
        if (cpu && psu && gpu && ssd & ram & fan && cpufan && motherboard && screwed == true)
        {
            Debug.Log("level completed");
            Debug.Log(timer);
        }
    }
}
