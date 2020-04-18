using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrawlerController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Transform target;

    private PlayerController player;

    public Rigidbody2D theRB;

    public Animator myAnim;

    private Vector2 moveDirection;

    public int health, spawnNum;
   
  

    void Start()
    {
        health = 50;
        speed = 0;
        myAnim = GetComponent<Animator>();
        theRB = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Invoke("SetSpeed", 1.4f); 
    }

    
    void Update()
    {
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //animates in direction player is moving
        CheckPlayerNull();
        WalkAnimation(); 
    }

    public void CheckPlayerNull()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetSpeed()
    {
        speed = 10.0f;
        myAnim.SetTrigger("spawnComplete");
    }
   
   private void WalkAnimation()
    {
        var superVelocity = theRB.velocity;
        //var localVelocity = transform.InverseTransformDirection(theRB.velocity);
        myAnim.SetFloat("moveX", superVelocity.x);  //animate movement based on direction...kind of
        myAnim.SetFloat("moveY", superVelocity.y);
    }
    
    //private void PlayerTracking()
    //{
    //    transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Sword") //damage from sword
        {
            myAnim.SetBool("isDead", true); //trigger death animation
            Invoke("Death", 0.15f);        //wait 0.15 seconds before destroying the object to let death animation play
        }

        if(other.tag == "Bullet" && health > 0) //damage from bullet
        {
            health -= 10;

            if(health <= 0)
            {
              myAnim.SetBool("isDead", true);
              Invoke("Death", 0.15f);
            }
        }
        
        if(other == player.body)
        {
            player.GetHurt(); //damage player
        }
    }

    public void Death()
    {
        player.AddScoreBrawler();
        Destroy(this.gameObject);
    }
}
