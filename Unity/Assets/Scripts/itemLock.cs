using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class itemLock : MonoBehaviour
{
    public enum Components { Screw, cpu, ram, ssd, fan, Case, Gpu, Wifi , Psu}

    public Components Component;
    [Header ("Other component")]
    public GameObject ItemAni;

    public GameObject ItemModel;
    [Header("Screw")]
    public GameObject screwComponent;
    //if needed
    public GameObject ItemCol;

    //if needed
    public GameObject RotateScrew;

    private bool screwTrue = false;
    private bool cpuTrue = false;
    private bool ramTrue = false;
    private bool ssdTrue = false;
    private bool fanTrue = false;
    private bool caseTrue = false;
    private bool gpuTrue = false;
    private bool wifiTrue = false;
    private bool psuTrue = false;
    public GameObject speedRunManager;
    public bool speedRun = false;
    
    private void Start()
    {
        if (speedRunManager.activeInHierarchy)
        {
            speedRun = speedRunManager.GetComponent<SpeedRunManager>().speedRun;
        }
    }

    void Update()
    {
        switch (Component)
        {
            case Components.Screw:
                screwTrue = true;
                break;
            case Components.cpu:
                cpuTrue = true;
                break;
            case Components.ram:
                ramTrue = true;
                break;
            case Components.ssd:
                ssdTrue = true;
                break;
            case Components.fan:
                fanTrue = true;
                break;
            case Components.Case:
                caseTrue = true;
                break;
            case Components.Gpu :
                gpuTrue = true;
                break;
            case Components.Wifi:
                wifiTrue = true;
                break;
            case Components.Psu:
                psuTrue = true;
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Screw" && screwTrue == true)
        {
            ItemCol.GetComponent<ScrewInteract>().enabled=true;
            ItemAni.SetActive(true);
            
            ItemModel.SetActive(false);
            this.gameObject.SetActive(false);
            if (speedRun)
            {
                speedRunManager.GetComponent<SpeedRunManager>().Screwed();
            }
        }
        if (collision.gameObject.tag == "Cpu" && cpuTrue == true)
        {
            //ItemCol.GetComponent<ScrewInteract>().enabled = true;
            ItemAni.SetActive(true);

            ItemModel.SetActive(false);
            this.gameObject.SetActive(false);
            if (speedRun)
            {
                speedRunManager.GetComponent<SpeedRunManager>().CPU();
            }
        }
        if (collision.gameObject.tag == "Ram" && ramTrue == true)
        {
            //ItemCol.GetComponent<ScrewInteract>().enabled = true;
            ItemAni.SetActive(true);

            ItemModel.SetActive(false);
            this.gameObject.SetActive(false);
            if (speedRun)
            {
                speedRunManager.GetComponent<SpeedRunManager>().RAM();
            }
        }
        if (collision.gameObject.tag == "Ssd" && ssdTrue == true)
        {
            //ItemCol.GetComponent<ScrewInteract>().enabled = true;
            ItemAni.SetActive(true);

            ItemModel.SetActive(false);
            this.gameObject.SetActive(false);
            screwComponent.SetActive(true);
            if (speedRun)
            {
                speedRunManager.GetComponent<SpeedRunManager>().SSD();
            }
        }
        if (collision.gameObject.tag == "Fan" && fanTrue == true)
        {
            //ItemCol.GetComponent<ScrewInteract>().enabled = true;
            ItemAni.SetActive(true);

            ItemModel.SetActive(false);
            this.gameObject.SetActive(false);
            screwComponent.SetActive(true);
            if (speedRun)
            {
                speedRunManager.GetComponent<SpeedRunManager>().Fan();
            }
        }
        if (collision.gameObject.tag == "Case" && caseTrue == true)
        {
            //ItemCol.GetComponent<ScrewInteract>().enabled = true;
            ItemAni.SetActive(true);

            ItemModel.SetActive(false);
            this.gameObject.SetActive(false);
            screwComponent.SetActive(true);
            if (speedRun)
            {speedRunManager.GetComponent<SpeedRunManager>().CASE();
            }
        }
        if (collision.gameObject.tag == "Gpu" && gpuTrue == true)
        {
            //ItemCol.GetComponent<ScrewInteract>().enabled = true;
            ItemAni.SetActive(true);

            ItemModel.SetActive(false);
            this.gameObject.SetActive(false);
            
            if (speedRun)
            {
                speedRunManager.GetComponent<SpeedRunManager>().GPU();
            }
        }
        if (collision.gameObject.tag == "Wfi" && wifiTrue == true)
        {
            //ItemCol.GetComponent<ScrewInteract>().enabled = true;
            ItemAni.SetActive(true);

            ItemModel.SetActive(false);
            this.gameObject.SetActive(false);

            if (speedRun)
            {
                speedRunManager.GetComponent<SpeedRunManager>().WIFI();
            }
        }
        if (collision.gameObject.tag == "PSU" && psuTrue == true)
        {
            //ItemCol.GetComponent<ScrewInteract>().enabled = true;
            //ItemAni.SetActive(true);

            ItemModel.SetActive(false);
            this.gameObject.SetActive(false);

            if (speedRun)
            {
                speedRunManager.GetComponent<SpeedRunManager>().PSU();
            }
        }
    }

}
