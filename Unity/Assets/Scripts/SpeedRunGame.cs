using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.Interaction.Toolkit;

public enum Components { screw, cpu, ram, ssd, fan, motherBoard, gpu, wifi, psu, gp}

public class SpeedRunGame : MonoBehaviour
{
    public Components thisComponent;
    public GameObject motherBoard;

    public GameObject speedRunManager;

    private void Update()
    {
        ProgressChecker();
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.tag =="Cpu" && thisComponent == Components.cpu)
        {
            this.transform.position = other.transform.position;
            this.transform.rotation = other.transform.rotation;
            this.transform.parent = motherBoard.transform;

            speedRunManager.GetComponent<ProgressCheck>().cpuIn = true;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<XRGrabInteractable>().enabled = false;
        }
        if (other.gameObject.tag =="Ram" && thisComponent == Components.ram)
        {
            this.transform.position = other.transform.position;
            this.transform.rotation = other.transform.rotation;
            this.transform.parent = motherBoard.transform;

            speedRunManager.GetComponent<ProgressCheck>().ramIn = true;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<XRGrabInteractable>().enabled = false;
        }
        if (other.gameObject.tag =="Ssd" && thisComponent == Components.ssd)
        {
            this.transform.position = other.transform.position;
            this.transform.rotation = other.transform.rotation;
            this.transform.parent = motherBoard.transform;

            speedRunManager.GetComponent<ProgressCheck>().ssdIn = true;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<XRGrabInteractable>().enabled = false;
        }
        if (other.gameObject.tag =="Cpu" && speedRunManager.GetComponent<ProgressCheck>().cpuIn == true && thisComponent == Components.fan)
        {
            this.transform.position = other.transform.position;
            this.transform.rotation = other.transform.rotation;
            this.transform.parent = motherBoard.transform;

            speedRunManager.GetComponent<ProgressCheck>().fanIn = true;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<XRGrabInteractable>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
        }
        if (other.gameObject.tag =="MotherBoard" && thisComponent == Components.motherBoard && (speedRunManager.GetComponent<ProgressCheck>().cpuIn &&
            speedRunManager.GetComponent<ProgressCheck>().ramIn && speedRunManager.GetComponent<ProgressCheck>().ssdIn &&
            speedRunManager.GetComponent<ProgressCheck>().fanIn) && speedRunManager.GetComponent<ProgressCheck>().screws == 5)
        {
            this.transform.position = other.transform.position;
            this.transform.rotation = other.transform.rotation;

            speedRunManager.GetComponent<ProgressCheck>().mBIn = true;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<XRGrabInteractable>().enabled = false;
        }
        if (other.gameObject.tag =="Gpu" && thisComponent == Components.gpu && speedRunManager.GetComponent<ProgressCheck>().mBIn)
        {
            this.transform.position = other.transform.position;
            this.transform.rotation = other.transform.rotation;
            this.transform.parent = motherBoard.transform;

            speedRunManager.GetComponent<ProgressCheck>().gpuIn = true;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<XRGrabInteractable>().enabled = false;
        }
        if (other.gameObject.tag =="Wfi" && thisComponent == Components.wifi && speedRunManager.GetComponent<ProgressCheck>().mBIn)
        {
            this.transform.position = other.transform.position;
            this.transform.rotation = other.transform.rotation;
            this.transform.parent = motherBoard.transform;

            speedRunManager.GetComponent<ProgressCheck>().wifiIn = true;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<XRGrabInteractable>().enabled = false;
        }
        if (other.gameObject.tag =="Psu" && thisComponent == Components.psu)
        {
            this.transform.position = other.transform.position;
            this.transform.rotation = other.transform.rotation;
            this.transform.parent = motherBoard.transform;

            speedRunManager.GetComponent<ProgressCheck>().psuIn = true;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<XRGrabInteractable>().enabled = false;
        }
        if (other.gameObject.tag =="Screw" && thisComponent == Components.screw)
        {
            this.transform.position = other.transform.position;
            this.transform.parent = other.transform;

            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<XRGrabInteractable>().enabled = false;
            speedRunManager.GetComponent<ProgressCheck>().screws = speedRunManager.GetComponent<ProgressCheck>().screws + 1;

        }

        if (other.gameObject.tag == "" && thisComponent == Components.gp && (speedRunManager.GetComponent<ProgressCheck>().cpuIn && speedRunManager.GetComponent<ProgressCheck>().ramIn
            && speedRunManager.GetComponent<ProgressCheck>().ssdIn && speedRunManager.GetComponent<ProgressCheck>().fanIn && speedRunManager.GetComponent<ProgressCheck>().mBIn &&
            speedRunManager.GetComponent<ProgressCheck>().gpuIn && speedRunManager.GetComponent<ProgressCheck>().wifiIn && speedRunManager.GetComponent<ProgressCheck>().psuIn))
        {
            this.transform.position = other.transform.position;
            this.transform.rotation = other.transform.rotation;
            this.transform.parent = motherBoard.transform;

            speedRunManager.GetComponent<ProgressCheck>().gpIn = true;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<XRGrabInteractable>().enabled = false;
        }
    }

    private void ProgressChecker()
    {
        if ((speedRunManager.GetComponent<ProgressCheck>().cpuIn && speedRunManager.GetComponent<ProgressCheck>().ramIn && speedRunManager.GetComponent<ProgressCheck>().ssdIn &&
            speedRunManager.GetComponent<ProgressCheck>().fanIn && speedRunManager.GetComponent<ProgressCheck>().mBIn && speedRunManager.GetComponent<ProgressCheck>().gpuIn &&
            speedRunManager.GetComponent<ProgressCheck>().wifiIn && speedRunManager.GetComponent<ProgressCheck>().psuIn)&& speedRunManager.GetComponent<ProgressCheck>().screws >=  13)
        {
            speedRunManager.GetComponent<SpeedRunManager>().GameEnd();
        }
    }
}
