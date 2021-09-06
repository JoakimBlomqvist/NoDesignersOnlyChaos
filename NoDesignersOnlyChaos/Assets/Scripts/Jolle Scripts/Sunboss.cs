using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Sunboss : Enemy
{
    [SerializeField] private GameObject SunBlast;
    [SerializeField] private float fireRate;
    [SerializeField] float nextFire;
    [SerializeField] private GameObject MiniSunboss;
    private Light2D _light2D;
    void Awake()
    {
        _light2D = GetComponent<Light2D>();
    }

    private void OnEnable()
    {
        nextFire = Time.time + 1f;
    }

    void Update()
    {
        if(isFreezed)
            return;
        FireRate();

    }

    void FireRate()
    {
        Debug.Log(nextFire - Time.time);
        _light2D.intensity = nextFire - Time.time;
        if (Time.time > nextFire)
        {
            var sublast = Instantiate(SunBlast, transform.position, Quaternion.identity);
            Physics2D.IgnoreCollision(sublast.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            nextFire = Time.time + fireRate;
        }


    }
    public void OnDeath()
    {
        if (MiniSunboss != null)
        {
            Instantiate(MiniSunboss, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 4f, gameObject.transform.position.z), Quaternion.identity);
            Instantiate(MiniSunboss, new Vector3(gameObject.transform.position.x + 4f, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
            Instantiate(MiniSunboss, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
            Instantiate(MiniSunboss, new Vector3(gameObject.transform.position.x - 4f, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
            Instantiate(MiniSunboss, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 4f, gameObject.transform.position.z), Quaternion.identity);
            Instantiate(MiniSunboss, new Vector3(gameObject.transform.position.x + 2f, gameObject.transform.position.y - 6f, gameObject.transform.position.z), Quaternion.identity);
            Instantiate(MiniSunboss, new Vector3(gameObject.transform.position.x + 6f, gameObject.transform.position.y + 4f, gameObject.transform.position.z), Quaternion.identity);
            Instantiate(MiniSunboss, new Vector3(gameObject.transform.position.x + 6f, gameObject.transform.position.y + 6f, gameObject.transform.position.z), Quaternion.identity);
        }
        //Instantiate(MiniSunboss,new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y ,gameObject.transform.position.z), Quaternion.identity);
    }
}
