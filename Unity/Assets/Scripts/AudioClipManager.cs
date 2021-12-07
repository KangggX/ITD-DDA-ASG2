using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipManager : MonoBehaviour
{

    static AudioSource audioSrc;
    public static AudioClip buttonSound, winSound, cleaningSound;

    // Start is called before the first frame update
    void Start()
    {
        //Load the sounds from the Resources folder
        buttonSound = Resources.Load<AudioClip>("button");
        winSound = Resources.Load<AudioClip>("win");
        cleaningSound = Resources.Load<AudioClip>("cleaning");
        
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        //Call references for other scripts to use
        switch(clip)
        {
            //if button is called, play button sound
            case "button":
                audioSrc.PlayOneShot(buttonSound);
                break;
            //if win is called, play win sound
            case "win":
                audioSrc.PlayOneShot(winSound);
                break;
            //if cleaning is called, play cleaning sound
            case "cleaning":
                audioSrc.PlayOneShot(cleaningSound);
                break;
        }
    }

    public void PlayButtonSound()
    {
        audioSrc.PlayOneShot(buttonSound);
    }
}
