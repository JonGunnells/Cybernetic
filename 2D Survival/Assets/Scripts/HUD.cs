using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public RectTransform mPanelGameOver, upgradePanel, healthPanel, health_good, health_average, health_critical;

    public RectTransform ammoBase, ammoOne, ammoTwo, ammoThree, ammoFour, ammoFive;

    public PlayerController player;

    public GameController gameController;

    public bool canUpgrade;

    public static bool GameIsFrozen = false;

    public GameObject upgrade;

    public Turret turret;


    public void CheckAmmo()
    {
        if(turret.maxAmmo == 50)
        {
            ammoBase.gameObject.SetActive(true);
            ammoOne.gameObject.SetActive(false);
            ammoTwo.gameObject.SetActive(false);
            ammoThree.gameObject.SetActive(false);
            ammoFour.gameObject.SetActive(false);
            ammoFive.gameObject.SetActive(false);
        }
        else if(turret.maxAmmo == 100)
        {
            ammoBase.gameObject.SetActive(false);
            ammoOne.gameObject.SetActive(true);
            ammoTwo.gameObject.SetActive(false);
            ammoThree.gameObject.SetActive(false);
            ammoFour.gameObject.SetActive(false);
            ammoFive.gameObject.SetActive(false);
        }
        else if(turret.maxAmmo == 150)
        {
            ammoBase.gameObject.SetActive(false);
            ammoOne.gameObject.SetActive(false);
            ammoTwo.gameObject.SetActive(true);
            ammoThree.gameObject.SetActive(false);
            ammoFour.gameObject.SetActive(false);
            ammoFive.gameObject.SetActive(false);
        }
        else if(turret.maxAmmo == 200)
        {
            ammoBase.gameObject.SetActive(false);
            ammoOne.gameObject.SetActive(false);
            ammoTwo.gameObject.SetActive(false);
            ammoThree.gameObject.SetActive(true);
            ammoFour.gameObject.SetActive(false);
            ammoFive.gameObject.SetActive(false);
        }
        else if (turret.maxAmmo == 250)
        {
            ammoBase.gameObject.SetActive(false);
            ammoOne.gameObject.SetActive(false);
            ammoTwo.gameObject.SetActive(false);
            ammoThree.gameObject.SetActive(false);
            ammoFour.gameObject.SetActive(true);
            ammoFive.gameObject.SetActive(false);
        }
        else if(turret.maxAmmo == 300)
        {
            ammoBase.gameObject.SetActive(false);
            ammoOne.gameObject.SetActive(false);
            ammoTwo.gameObject.SetActive(false);
            ammoThree.gameObject.SetActive(false);
            ammoFour.gameObject.SetActive(false);
            ammoFive.gameObject.SetActive(true);
        }
    }

    public void HealthGood()
    {
        health_good.gameObject.SetActive(true);
        health_average.gameObject.SetActive(false);
        health_critical.gameObject.SetActive(false);
    }

    public void HealthAverage()
    {
        health_good.gameObject.SetActive(false);
        health_average.gameObject.SetActive(true);
        health_critical.gameObject.SetActive(false);
    }

    public void HealthCritical()
    {
        health_good.gameObject.SetActive(false);
        health_average.gameObject.SetActive(false);
        health_critical.gameObject.SetActive(true);
    }

    public void HealthHud()
    {
        if (player.currentHealth >= 100)
        {
            HealthGood();
        }
        else if (player.currentHealth < 100 && player.currentHealth > 25)
        {
            HealthAverage();
        }
        else if (player.currentHealth <= 25)
        {
            HealthCritical();
        }
    }

    private void Start()
    {
        turret = GameObject.Find("Turret(Clone)").GetComponent<Turret>();
    }

    void Update()
    {
        CheckHealth();
        CheckScore();
        HealthHud();
        CheckAmmo();

        if (upgrade.activeInHierarchy == true)
        {
            Pause();
        }
        else if(upgrade.activeInHierarchy == false)
        {
            Resume();
        }    
    }

    void Resume()
    {
        Time.timeScale = 1f;
        GameIsFrozen = false;
    }

    void Pause()
    {
        Time.timeScale = 0f;
        GameIsFrozen = true;
    }

    public void CheckHealth()
    {
        if (player.currentHealth <= 0 && player != null)
        {
            mPanelGameOver.gameObject.SetActive(true);  
        }
    }

    public void CheckScore()
    {
        if (canUpgrade)
        {
            upgradePanel.gameObject.SetActive(true);
        }  
    }

   
}
