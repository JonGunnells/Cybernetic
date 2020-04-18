using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Turret : MonoBehaviour
{
    public Text ammoText;

    public HUD hud;

    public AudioSource myFx;

    public AudioClip gunshot;

    public Animator myAnim;

    private float distanceX, distanceY, fireRate = 0.1f, nextFire = 0.0f;

    private PlayerController player;

    private Transform target;
    
    public Rigidbody2D theRB;

    public int currentAmmo, maxAmmo, hudChildCount;

    public GameObject bulletPrefab;

    void Start()
    {
        currentAmmo = 50;
        maxAmmo = 50;
        ammoText = GameObject.Find("AmmoText").GetComponent<Text>();
        theRB = GetComponent<Rigidbody2D>();
        //Invoke("FindPlayer", 0.5f);
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        target = GameObject.Find("Player").GetComponent<Transform>();

    }

    void Update()
    {
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        CheckDistance();
        CheckIfShooting();
        ammoText.text = currentAmmo + " / " + maxAmmo;
        //Debug.Log("CURRENT AMMO: " + currentAmmo + "   MAX AMMO: " + maxAmmo);
    }

    public void AmmoPickup()
    {
        currentAmmo += 50;
        
        if(currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
    }
    
    public void CheckIfShooting()
    {
        if (Input.GetMouseButton(1) && currentAmmo >= 1)
        {
            FollowMouseShooting();
            Shoot();   
        }
        else
        {
            FollowMouseIdle();
        } 
    }

    public void FollowMouseIdle()  //animate drone while not shooting
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        myAnim.SetBool("attacking", false);
        myAnim.SetFloat("lastMoveX", dir.x);
        myAnim.SetFloat("lastMoveY", dir.y);
    }

    public void FollowMouseShooting() //animate drone while shooting
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //this.GetComponent<Animator>().SetTrigger("Attacking");
        myAnim.SetBool("attacking", true);
        myAnim.SetFloat("moveX", dir.x);
        myAnim.SetFloat("moveY", dir.y);
    }

    public void Shoot()
    {
        if (Input.GetMouseButton(1) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
            myFx.PlayOneShot(gunshot);
            currentAmmo -= 1;
        }
    }

    private void PlayerTracking()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, player.moveSpeed * Time.deltaTime);
        }
    }

    private void CheckDistance()
    {
        if (player != null)
        {
            distanceX = (target.transform.position.x - transform.position.x);
            distanceY = (target.transform.position.y - transform.position.y);

            if (distanceX > 10.0f || distanceX < -10.0f)
            {
                PlayerTracking();
            }
            else if (distanceY > 10.0f || distanceY < -10.0f)
            {
                PlayerTracking();
            }
        }
        
    }
}
