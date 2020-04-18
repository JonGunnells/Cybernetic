using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SploderProjectile : MonoBehaviour
{

    private float speed;

    private Transform target;

    private PlayerController player;

    public Animator myAnim;

    private Vector2 moveDirection;

    public Rigidbody2D theRB;

    public int health = 30;


    
    void Start()
    {
        speed = 25;
        myAnim = GetComponent<Animator>();
        theRB = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    
    void Update()
    {
        CheckPlayerNull();
    }

    public void CheckPlayerNull()
    {
        if(player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            health -= 10;
            if(health <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        if(collision.tag == "Player")
        {
            //player.GetHurt();
            speed = 0f;
            myAnim.SetTrigger("explode");
            Invoke("Explode", 1.0f);
        }
    }

    public void Explode()
    {
        Destroy(this.gameObject);
    }
}
