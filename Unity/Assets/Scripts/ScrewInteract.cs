using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewInteract : MonoBehaviour
{
    public float currentRotation;
    public float previousRotation;
    public float targetValue;
    public int score;

    public Animator ScrewAni;
    private void Start()
    {
        targetValue = 1440;
        previousRotation = 0;
        currentRotation = transform.eulerAngles.z;
    }

    private void Update()
    {
        if (score >= 2)
        {
            ScrewAni.SetBool("Screwing", true);
            print("anime play");
            this.gameObject.SetActive(false);
        }
    }

    //on release
    public void ScrewRotate()
    {
        previousRotation = currentRotation;
        currentRotation = currentRotation - previousRotation;
        targetValue = targetValue - currentRotation;
        if(targetValue >= 0)
        {
            score = score + 1;
        }
    }


}
