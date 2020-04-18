using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialButton : MonoBehaviour
{
    public void StartTutorial()
    {
        SceneManager.LoadScene("Tutorial1");
    }
}
