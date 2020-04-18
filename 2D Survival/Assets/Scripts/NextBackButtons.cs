using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextBackButtons : MonoBehaviour
{
   public void Next()
    {
        SceneManager.LoadScene("Tutorial2");
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void BackToTutorialOne()
    {
        SceneManager.LoadScene("Tutorial1");
    }
}
