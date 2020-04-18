using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthButton : MonoBehaviour
{

    public PlayerController player;

    public GameController gameController;

    public SpawnManager spawnManager;


    public void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();

    }
    public void AddHealth()
    {
        if (player.upgradePoints > 0)
        {
            player.upgradePoints -= 1;
            player.maxHealth += 25;
            spawnManager.enemyNum = 0;
            spawnManager.canSpawn = true;
            
        }
    }
}
