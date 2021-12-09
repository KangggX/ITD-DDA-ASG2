using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHighlight : MonoBehaviour
{
    //This will use the emission property to highlight the object
    public void OnHover()
    {
        //Get all the meshrenderers that make up this object
        MeshRenderer[] meshRenderer = GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer renderer in meshRenderer)
        {
            renderer.material.EnableKeyword("_EMISSION");
        }
        //Look through all the  renderers and tell their materials to turn on emission
    }

    //This will user the emission property to stop highlighting the object
    public void ExitHover()
    {
        //Get all the meshrenderers that make up this object
        MeshRenderer[] meshRenderer = GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer renderer in meshRenderer)
        {
            renderer.material.DisableKeyword("_EMISSION");
        }
    }
}