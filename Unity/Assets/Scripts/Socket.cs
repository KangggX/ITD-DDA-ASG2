using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
    public GameObject guide;

    public void StartGuide()
    {
        guide.gameObject.SetActive(true);
    }

    public void EndGuide()
    {
        guide.gameObject.SetActive(false);
    }
}
