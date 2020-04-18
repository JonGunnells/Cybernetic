using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairButton : MonoBehaviour
{
    public PlayerController player;
    public SpawnManager spawnManager;
    public Turret turret;
    public GameController gameController;
    public HUD hud;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        turret = GameObject.Find("Turret(Clone)").GetComponent<Turret>();
    }

    public void RepairReload()
    {
        if(player.upgradePoints > 0)
        {
            player.upgradePoints -= 1;
            player.currentHealth = player.maxHealth;
            turret.currentAmmo = turret.maxAmmo;
            spawnManager.enemyNum = 0;
            spawnManager.canSpawn = true;
        }
    }
}
