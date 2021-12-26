using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ramCheck : MonoBehaviour
{
    public Collider ramCol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="ram1"||collision.gameObject.tag=="ram2" || collision.gameObject.tag == "ram3" || collision.gameObject.tag == "ram4")
        {
            this.ramCol.enabled = false;
        }
    }
}
