using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemLock : MonoBehaviour
{
    public Transform ItemPos;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Screw")
        {
            
            this.transform.position = ItemPos.position;
            print("nooooo");
        }
    }
}
