using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip hoverFx;
    public AudioClip clickFx;
    public AudioClip derezzed;
   

    public void HoverSound()
    {
        myFx.PlayOneShot(hoverFx);  
    }
    public void ClickSound()
    {
        myFx.PlayOneShot(clickFx);
    }

    public void StartMusic()
    {
        myFx.PlayOneShot(derezzed);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Scene01");
    }
}
