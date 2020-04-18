using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public Turret turret;

    public void Start()
    {
        turret = GameObject.Find("Turret(Clone)").GetComponent<Turret>();
        Invoke("Degrade", 5.0f);
    }

    private void Update()
    {
       // Debug.Log(turret.currentAmmo);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            turret.AmmoPickup();
            Destroy(this.gameObject);
        }
    }   
    
    public void Degrade()
    {
        Destroy(this.gameObject);
    }
} 