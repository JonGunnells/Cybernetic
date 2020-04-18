using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SploderController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public GameObject ammoDrop;
    private Transform target;
    private PlayerController player;
    public Rigidbody2D theRB;
    public Animator myAnim;
    private Vector2 moveDirection;
    public int health, spawnNum;
    public SploderProjectile projectile;

    void Start()
    {
        health = 80;
        DropNuber();   //create random number to decide if it will drop ammo on death
        speed = 0;
        myAnim = GetComponent<Animator>();
        theRB = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Invoke("SetSpeed", 1.0f);
        Invoke("Attack", 5.0f);
    }

    

    void Update()
    {
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //animates in direction player is moving
        //PlayerTracking();
        WalkAnimation();
        CheckPlayerNull();
    }

    public void SetSpeed()
    {
        speed = 5.0f;
        myAnim.SetTrigger("spawnComplete");
    }

    private void WalkAnimation()
    {
        var superVelocity = theRB.velocity;
        //var localVelocity = transform.InverseTransformDirection(theRB.velocity);
        myAnim.SetFloat("moveX", superVelocity.x);  //animate movement based on direction...kind of
        myAnim.SetFloat("moveY", superVelocity.y);
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

        if (other.tag == "Bullet" && health > 0) //damage from bullet
        {
            health -= 10;

            if (health <= 0)
            {
                myAnim.SetBool("isDead", true);
                Invoke("Death", 0.15f);
            }
        }

        if (other == player.body)
        {
            player.GetHurt(); //damage player
        }
    }

    public void Death()
    {
        player.AddScoreSploder();

        if (spawnNum == 2)
        {
            Instantiate(ammoDrop, transform.position, ammoDrop.transform.rotation);
        }

        Destroy(this.gameObject);
    }

    public void Suicide()
    {
        Destroy(this.gameObject);
    }

    public void Attack()
    {
        speed = 0f;
        myAnim.SetTrigger("attack");
        Invoke("FireProjectile", 1.5f);
        Invoke("Suicide", 1.5f);
    }

    public void FireProjectile()
    {
        Instantiate(projectile, transform.position + new Vector3( 0.0f, 10.0f, 0), projectile.transform.rotation);
    }

    public void DropNuber()
    {
        spawnNum = Random.Range(1, 7);
    }
}
