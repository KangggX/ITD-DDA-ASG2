using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCheck : MonoBehaviour
{
    public enum ItemChecker {ram, screw}
    public ItemChecker ItemCheckers;

    public int numInCheck;
    public static int _ram;
    public GameObject currentPart;
    public GameObject nextPart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        switch (ItemCheckers)
        {
            case ItemChecker.ram:
               
                if (_ram == numInCheck)
                {
                    currentPart.SetActive(false);
                    nextPart.SetActive(true);
                }
                break;
            case ItemChecker.screw:

                break;
        }
        
    }
}
