using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class itemLock : MonoBehaviour
{
    public enum Components { Screw, cpu , ram}

    public Components Component;
    [Header ("Other component")]
    public GameObject ItemAni;

    public GameObject ItemModel;
    [Header ("Screw")]
    //if needed
    public GameObject ItemCol;

    //if needed
    public GameObject RotateScrew;

    private bool screwTrue = false;
    private bool cpuTrue = false;
     void Start()
    {
        
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
            
        }
        if (collision.gameObject.tag == "Cpu" && cpuTrue == true)
        {
            //ItemCol.GetComponent<ScrewInteract>().enabled = true;
            ItemAni.SetActive(true);

            ItemModel.SetActive(false);
            this.gameObject.SetActive(false);

        }
    }
}
