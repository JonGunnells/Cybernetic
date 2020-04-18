using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public RectTransform roundDisplay;

    public Text roundText;

    public Turret turret;

    public AudioSource myFx;

    public AudioClip pY, b;

    public PlayerController player;

    public Pause1 pauseMenu;

    public SpawnManager spawnManager;

    public HUD hud;

    public int level; 

    void Start()
    {
        
        level = 1;
        Invoke("prepareYourself", 0.5f);
        Invoke("beginAudio", 4.0f);
        //roundDisplay = GameObject.Find("Level").GetComponent<RectTransform>();
        //roundText = GameObject.Find("LevelText").GetComponent<Text>();
        Instantiate(turret);
    }

    void Update()
    {
        LevelSystem();
        //pauseMenu.PauseTheGame(); 
    }

    public void prepareYourself()
    {
        myFx.PlayOneShot(pY);
    }

    public void beginAudio()
    {
        myFx.PlayOneShot(b);
    }


    public void BoardClear()
    {
        var clones = GameObject.FindGameObjectsWithTag("Enemy");
        var splosions = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
        foreach(var splosion in splosions)
        {
            Destroy(splosion);
        }
    }

    public void LevelSystem() 
    {
        if (level == 1 && player.currentScore >= 200)
        {
            hud.canUpgrade = true;
            player.upgradePoints += 1;
            player.currentScore = 0;
            level = 2;
            spawnManager.spawnRate = 2.5f;
            BoardClear();
        }
        else if (level == 2 && player.currentScore >= 400)
        {
            
            hud.canUpgrade = true;
            player.upgradePoints += 1;
            player.currentScore = 0;
            level = 3;
            spawnManager.spawnRate = 2.0f;
            BoardClear();
        }
        else if (level == 3 && player.currentScore >= 600)
        {
            hud.canUpgrade = true;
            player.upgradePoints += 1;
            player.currentScore = 0;
            level = 4;
            spawnManager.spawnRate = 1.5f;
            BoardClear();
        }
        else if (level == 4 && player.currentScore >= 700)
        {
            hud.canUpgrade = true;
            player.upgradePoints += 1;
            player.currentScore = 0;
            level = 5;
            spawnManager.spawnRate = 1.0f;
            BoardClear();
        }
        else if (level == 5 && player.currentScore >= 800)
        {
            hud.canUpgrade = true;
            player.upgradePoints += 1;
            player.currentScore = 0;
            level = 6;
            BoardClear();
        }
        else if (level == 6 && player.currentScore >= 800)
        {
            hud.canUpgrade = true;
            player.upgradePoints += 1;
            player.currentScore = 0;
            level = 7;
            spawnManager.spawnRate = 0.75f;
            BoardClear();
            
        }
        else if (level == 7 && player.currentScore >= 900)
        {
            spawnManager.gameObject.SetActive(false);
            BoardClear();
            roundText.text = "WINNER";
            roundDisplay.gameObject.SetActive(true);
            Invoke("RollCredits", 3.0f);
            //winner.gameObject.SetActive(true);
        }
    }


    public void RollCredits()
    {
        SceneManager.LoadScene("Credits");
    }

   





}
