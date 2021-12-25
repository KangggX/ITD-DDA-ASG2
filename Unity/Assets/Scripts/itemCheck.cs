using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class itemCheck : MonoBehaviour
{
    public enum ItemChecker {ram, screw, screw1, screw2, gpuwifi, psu, panel}
    public ItemChecker ItemCheckers;

    public int numInCheck;
    public static int _ram;
    public static int _screw;
    public static int _screw1;
    public static int _screw2;
    public static int _gpuwifi;
    public static int _psu;
    public static int _panel;
    public GameObject currentPart;
    public GameObject nextPart;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        _screw = 0;     
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
                if (_screw == numInCheck)
                {
                    
                    currentPart.SetActive(false);
                    nextPart.SetActive(true);
                }
                break;
            case ItemChecker.screw1:
                if (_screw1 == numInCheck)
                {
                    
                    currentPart.SetActive(false);
                    nextPart.SetActive(true);
                }
                break;
            case ItemChecker.screw2:
                if (_screw2 == numInCheck)
                {

                    currentPart.SetActive(false);
                    nextPart.SetActive(true);
                }
                break;
            case ItemChecker.gpuwifi:
                if (_gpuwifi == numInCheck)
                {

                    currentPart.SetActive(false);
                    nextPart.SetActive(true);
                }
                break;
            case ItemChecker.psu:
                if (_psu == numInCheck)
                {

                    currentPart.SetActive(false);       
                    nextPart.SetActive(true);
                }
                break;
            case ItemChecker.panel:
                if (_panel == numInCheck)
                {
                    SceneManager.LoadScene("Main Menu");
                    
                }
                break;
        }
        
    }
}
