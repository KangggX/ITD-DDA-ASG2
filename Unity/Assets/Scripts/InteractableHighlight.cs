    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHighlight : MonoBehaviour
{
    //This will use the emission property to highlight the object
    public void OnHover()
    {
        //Get all the MeshRenderers that make up this object
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();

        //Look through all the renderers and tell their materials to turn on emission
        foreach(MeshRenderer renderer in meshRenderers)
        {
            renderer.material.EnableKeyword("_EMISSION");
        }
    }

    //This will use the emission property to stop highlighting the object
    public void ExitHover()
    {
        //Get all the MeshRenderers that make up this object
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();

        //Look through all the renderers and tell their materials to turn off emission
        foreach (MeshRenderer renderer in meshRenderers)
        {
            renderer.material.DisableKeyword("_EMISSION");
        }
    }
}
