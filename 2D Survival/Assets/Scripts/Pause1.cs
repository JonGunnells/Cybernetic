using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause1 : MonoBehaviour
{
    public bool IsPaused;
    public SpawnManager spawnManager;
    public GameObject PauseMenu;


    private void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    private void Update()
    {
        if (IsPaused)
        {
            PauseMenu.SetActive(true);
            spawnManager.isPaused = true;
        }
        else
        {
            PauseMenu.SetActive(false);
            spawnManager.isPaused = false;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            IsPaused = !IsPaused;
        }
    }






    //public void PauseTheGame()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        player = GameObject.Find("Player").GetComponent<PlayerController>();
    //        brawler = GameObject.Find("Brawler(Clone)").GetComponent<BrawlerController>();
    //        sploder = GameObject.Find("Sploder(Clone)").GetComponent<SploderController>();
    //        Debug.Log("PAUSED");
    //        IsPaused = !IsPaused;
    //    }

    //    if (IsPaused)
    //    {
    //        PauseMenu.SetActive(true);
    //        player.theRB.constraints = RigidbodyConstraints2D.FreezeAll;
    //        brawler.gameObject.SetActive(false);
    //        sploder.gameObject.SetActive(false);


    //    }
    //    else
    //    {
    //        PauseMenu.SetActive(false);
    //        player.theRB.constraints = RigidbodyConstraints2D.None;

    //    }

    //}  
}
