using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeToQuote : MonoBehaviour
{
    
    void Start()
    {
        //Invoke("LoadFinalScene", 43.0f);
    }

    public void LoadFinalScene()
    {
        SceneManager.LoadScene("EndQuote");
    }
}
