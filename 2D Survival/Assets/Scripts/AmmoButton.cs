using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoButton : MonoBehaviour
{
    public Turret turret;

    public PlayerController player;

    public SpawnManager spawnManager;

    public void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        turret = GameObject.Find("Turret(Clone)").GetComponent<Turret>();
    }

    public void AddAmmo()
    {
        if(player.upgradePoints > 0)
        {
            player.upgradePoints -= 1;
            turret.maxAmmo += 50;
            spawnManager.enemyNum = 0;
            spawnManager.canSpawn = true;
        }
    }
}
