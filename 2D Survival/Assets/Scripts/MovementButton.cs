using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovementButton : MonoBehaviour
{
    public SpawnManager spawnManager;
    public PlayerController player;
    public GameController gameController;
    public HUD hud;
    
   

    public void UpgradeMoveSpeed()
    {
        if (player.upgradePoints > 0)
        {
            player.upgradePoints -= 1;
            player.sprintSpeed += 10;
            player.defaultSpeed += 10;
            spawnManager.enemyNum = 0;
            spawnManager.canSpawn = true;
            spawnManager.SpawnShitSequence();
        }  
    }
}
