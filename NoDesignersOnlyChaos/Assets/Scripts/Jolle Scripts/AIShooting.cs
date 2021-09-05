using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShooting : Enemy
{
    [SerializeField] private GameObject AI_bullet;
    [SerializeField] private float fireRate;
    [SerializeField] float nextFire;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        fireRate = 1f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFreezed)
            return;
        
        if (AI_Bullet.player_Alive == false)
        {
            FireRate();
        }
            
    }

    void FireRate()
    {
        if (Time.time > nextFire)
        {
        GameObject bullet = Instantiate(AI_bullet, transform.position, Quaternion.identity);
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        nextFire = Time.time + fireRate;
        }
    }
}
