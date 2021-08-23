using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShooting : MonoBehaviour
{
    [SerializeField] private GameObject AI_bullet;
    [SerializeField]private float fireRate;
    [SerializeField]float nextFire;
    [SerializeField] private Transform Shootingpoint;
    
    // Start is called before the first frame update
    void Awake()
    {
        fireRate = 1f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        FireRate();
    }

    void FireRate()
    {
        //if( AI_Bullet.player_Alive == false)
        //{
            if (Time.time > nextFire)
            {
                Instantiate(AI_bullet, transform.position, Quaternion.identity);
                //Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                nextFire = Time.time + fireRate;
            }
        //}
        
    }
}
