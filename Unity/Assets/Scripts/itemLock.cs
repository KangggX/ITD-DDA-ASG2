using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class itemLock : MonoBehaviour
{
    //if needed
    public GameObject ItemCol;
    
    public GameObject ItemAni;

    public GameObject ItemModel;
    //if needed
    public GameObject RotateScrew;
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Screw")
        {
            ItemCol.GetComponent<ScrewInteract>().enabled=true;
            ItemAni.SetActive(true);
            
            ItemModel.SetActive(false);
            this.gameObject.SetActive(false);
            
        }
    }
}
