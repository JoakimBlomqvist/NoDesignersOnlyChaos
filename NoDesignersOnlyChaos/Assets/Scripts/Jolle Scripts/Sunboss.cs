using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunboss : MonoBehaviour
{
    [SerializeField] private GameObject SunBlast;
    [SerializeField] private float fireRate;
    [SerializeField] float nextFire;
    [SerializeField] private GameObject MiniSunboss;

    void Awake()
    {
        
        nextFire = Time.time;
    }
    private void OnDisable()
    {
        if(MiniSunboss != null)
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
