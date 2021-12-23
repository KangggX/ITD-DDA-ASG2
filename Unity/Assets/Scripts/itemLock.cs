using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class itemLock : MonoBehaviour
{
    //if needed
    public GameObject ItemCol;
    
    public GameObject ItemAni;
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
            this.gameObject.SetActive(false);
            
        }
    }
}
