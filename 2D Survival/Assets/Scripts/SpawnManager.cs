using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject brawlerPrefab, sploderPrefab, enemy;

    [SerializeField]
    private GameObject enemyContainer;

    public bool canSpawn, isPaused;

    public int enemyNum, lastSpawn, spawnPos;

    private PlayerController player;

    [SerializeField]
    private GameObject spawnManager;

    private int maxNum;

    public float spawnRate;

    public GameController gameController; 


    void Start()
    {
        isPaused = false;
        spawnRate = 3.0f;
        Invoke("FindPlayer", 0.5f);
        canSpawn = true;
        Invoke("SpawnShitSequence", 4.0f);
        //StartCoroutine(SpawnRoutine());
    }


    void Update()
    {
        CheckTime();
        //checkLevel();
        //Debug.Log("ENEMY NUM: " + enemyNum + "  MAX NUM: " + maxNum);
    }

    public void CheckTime()
    {
        if(isPaused == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void FindPlayer()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void checkLevel()
    {
        maxNum = gameController.level * 10;
        if(enemyNum == maxNum)
        {
            //canSpawn = false;
        }
        else
        {
            canSpawn = true;
        }
    }

    public void SpawnShitSequence()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Vector2 one = new Vector2(-70, 26);
            Vector2 two = new Vector2(75, 24);
            Vector2 three = new Vector2(-73, -27);
            Vector2 four = new Vector2(75, -26);

            lastSpawn = spawnPos;

            spawnPos = Random.Range(1, 4);

            if (spawnPos != lastSpawn)
            {

                int enemyType = Random.Range(1, 5);

                if (enemyType % 2 == 0)
                {
                    enemy = sploderPrefab;
                }
                else
                {
                    enemy = brawlerPrefab;
                }

                if (spawnPos == 1)
                {
                    GameObject newEnemy = Instantiate(enemy, one, Quaternion.identity);
                    newEnemy.transform.parent = enemyContainer.transform;
                    enemyNum++;
                }
                else if (spawnPos == 2)
                {
                    GameObject newEnemy = Instantiate(enemy, two, Quaternion.identity);
                    newEnemy.transform.parent = enemyContainer.transform;
                    enemyNum++;
                }
                else if (spawnPos == 3)
                {
                    GameObject newEnemy = Instantiate(enemy, three, Quaternion.identity);
                    newEnemy.transform.parent = enemyContainer.transform;
                    enemyNum++;
                }
                else if (spawnPos == 4)
                {
                    GameObject newEnemy = Instantiate(enemy, four, Quaternion.identity);
                    newEnemy.transform.parent = enemyContainer.transform;
                    enemyNum++;
                }
                
                yield return new WaitForSeconds(spawnRate);
            }
        }
    }
}
