using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCount : MonoBehaviour
{
    public static int item;
    private bool i = true;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void Awake()
    {
        
        if (i == true)
        {
            print("wda");
            itemCheck._ram += 1;
            i = false;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
