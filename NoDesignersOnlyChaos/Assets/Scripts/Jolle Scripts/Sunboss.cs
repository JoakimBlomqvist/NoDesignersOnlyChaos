using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunboss : MonoBehaviour
{
    [SerializeField] private GameObject SunBlast;
    [SerializeField] private float fireRate;
    [SerializeField] float nextFire;
    

    void Awake()
    {
        
        nextFire = Time.time;
    }


    void Update()
    {

            FireRate();

    }

    void FireRate()
    {

        if (Time.time > nextFire)
        {
            var sublast = Instantiate(SunBlast, transform.position, Quaternion.identity);
            Physics2D.IgnoreCollision(sublast.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            nextFire = Time.time + fireRate;
        }


    }

}
