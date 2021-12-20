using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class handPresense : MonoBehaviour
{
    // Start is called before the first frame update
    private InputDevice targetDevice;
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacterics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacterics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }
        if (devices.Count>0)
        {
            targetDevice = devices[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool primaryButtonValue);
        if (primaryButtonValue)
        {
            Debug.Log("pressing trigger Button");
        }
    }
}
