using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCount : MonoBehaviour
{
    public enum types { ram, screw1,screw2, screw3 , gpu, pannel}
    public types _type;
    public static int item;
    private bool part2 = true;
    private bool part3 = true;
    private bool part4 = true;
    private bool part5 = true;
    private bool part6 = true;
    private bool part7 = true;
    // Start is called before the first frame update
    void Start()
    {
        switch (_type)
        {
            case types.ram:
                if (part2 == true)
                {
                    print("wda");
                    itemCheck._ram += 1;
                    part2 = false;
                }
                break;
            case types.screw1:
                if (part3 == true)
                {
                    print("wda");
                    itemCheck._screw += 1;
                    part3 = false;
                }
                break;
            case types.screw2:
                if (part4 == true)
                {
                    print("wda");
                    itemCheck._screw1 += 1;
                    part4 = false;
                }
                break;
            case types.screw3:
                if (part5 == true)
                {
                    print("wda");
                    itemCheck._screw2 += 1;
                    part5 = false;
                }
                break;
            case types.gpu:
                if (part6 == true)
                {
                    print("wda");
                    itemCheck._gpuwifi += 1;
                    part6 = false;
                }
                break;
            case types.pannel:
                if (part7 == true)
                {
                    print("wda");
                    itemCheck._panel += 1;
                    part6 = false;
                }
                break;
        }
    }
    private void Awake()
    {
            
        
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
