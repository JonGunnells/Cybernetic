using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D theRB;

    public CircleCollider2D body;

    public float moveSpeed, defaultSpeed, sprintSpeed;

    public Animator myAnim;

    public int currentScore, totalScore, upgradePoints, currentHealth, maxHealth, enemiesKilled;

    public Turret turret;

    [SerializeField]
    private Text scoreText, healthText;

    [SerializeField]
    private RectTransform mPanelGameOver;

    public GameController gameController;

    

    void Start()
    {
        
        healthText = GameObject.Find("HealthText").GetComponent<Text>();
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        //mPanelGameOver = GameObject.Find("killScreen").GetComponent<RectTransform>();
        upgradePoints = 0;
        currentHealth = 100;
        maxHealth = 100;
        defaultSpeed = 20;
        sprintSpeed = 50;
        scoreText.text = "SCORE: " + currentScore;
    }

  

    void Update()
    {
        
        HudUpdate();
        checkHealth();
        Movement();
        MoveAnimation();
        Attack();
        Sprint();
        
    }

    public void Movement()
    {
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed; //movement speed for player
    }

    public void MoveAnimation()
    {
        myAnim.SetFloat("moveX", theRB.velocity.x);  //sets animation for player based on direction
        myAnim.SetFloat("moveY", theRB.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1) //sets animation to last known position
        {
            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical")); 
        }
    }

    public void HudUpdate()
    {
        scoreText.text = "SCORE: " + totalScore; //+ "   UPGRADE POINTS: " + upgradePoints;      //update score 
        healthText.text = " HEALTH: " + currentHealth + " / " + maxHealth;
    }

    public void Attack()
    {
        if (Input.GetButtonDown("Fire1"))  //add in check if not attacking here
        {
            StartCoroutine(AttackCo());
        }  
    }

    public void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = sprintSpeed;
        }
        else
        {
            moveSpeed = defaultSpeed;
        } 
    }

    private IEnumerator AttackCo() //attack animation
    {
        myAnim.SetBool("attacking", true);
        //add in check for if currently attacking here
        yield return null;
        myAnim.SetBool("attacking", false);
        yield return new WaitForSeconds(.5f); 
    }

    public void checkHealth()
    {
        //Debug.Log("CURRENT HEALTH: " + currentHealth + "   MAX HEALTH: " + maxHealth + "   AMMO: " + turret.ammo);
        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void GetHurt()  //reduce health when hit
    {
        if(currentHealth >= 25)
        {
            currentHealth -= 25;
        }
    }

    public void AddScoreBrawler()  //add score per each kill
    {
        currentScore += 10;
        totalScore += 10;
        enemiesKilled += 1;
    }

    public void AddScoreSploder()
    {
        currentScore += 20;
        totalScore += 20;
        enemiesKilled += 1;
    }
}
