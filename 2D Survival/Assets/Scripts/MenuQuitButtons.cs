using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuQuitButtons : MonoBehaviour
{
   public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT PRESSED");
        Application.Quit();
    }
    
}
