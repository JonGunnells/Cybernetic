using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuExitButton : MonoBehaviour
{
    public RectTransform upgradeMenu, roundDisplay;
    public Text roundText;
    public GameController gameController;
    public HUD hud;
    public int level;
    
    
    void Start()
    {
       level = gameController.level;
    }

    
    void Update()
    {
        level = gameController.level;
    }

    public void ExitMenu()
    {
        hud.canUpgrade = false;
        upgradeMenu.gameObject.SetActive(false);
        if (level == 7)
        {
            roundText.text = "FINAL ROUND: SURVIVE THE SWARM";
        }
        else
        {
            roundText.text = "ROUND " + level;
        }
        roundDisplay.gameObject.SetActive(true);
        Invoke("roundBannerOff", 1.0f);
        

    }



    public void roundBannerOff()
    {
        roundDisplay.gameObject.SetActive(false);
    }
}
