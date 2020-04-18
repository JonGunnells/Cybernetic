using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    private float speed;

    private Vector3 moveDirection;




    void Start()
    {
        speed = 300.0f;
        moveDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position); // follow mouse cursor
        moveDirection.z = 0;
        moveDirection.Normalize();
    }

    
    void Update()
    {
        transform.position = transform.position + moveDirection * speed * Time.deltaTime; //set speed

        if(transform.position.y < -55 || transform.position.y > 50 || transform.position.x < -90 || transform.position.x > 90)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" || collision.tag == "Car" || collision.tag == "Projectile")
        {
            Destroy(this.gameObject);
        }
    }
}
