using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

[System.Serializable]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 1;
    public XRNode inputSource;
    [System.Obsolete]
    public XROrigin rig;
    private Vector2 inputAxis;
    private CharacterController character;
    public Camera playerCamera;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XROrigin>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
        
    }
    [System.Obsolete]
    private void FixedUpdate()
    {
        Quaternion headYaw = Quaternion.Euler(0, playerCamera.transform.eulerAngles.y, 0);  
        Vector3 direction =headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);

        character.Move(direction * Time.fixedDeltaTime * speed);
    }
}
