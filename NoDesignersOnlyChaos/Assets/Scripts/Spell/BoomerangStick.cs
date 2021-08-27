using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class BoomerangStick : MonoBehaviour
{
    private Vector2 impactPoint;
    private Vector2 startPoint;
    
    [SerializeField,Range(0,1f)] private float speedRateCast;
    [SerializeField, Range(0, 1f)] private float speedRateReturn;
    [SerializeField] private int damage;
    private Transform playerT;
    private float spin;
    [SerializeField] private float spinRate;
    
    
    private Vector3 velocity;

    private bool reachedPoint;
    
    void Start()
    {
        playerT = FindObjectOfType<PlayerAimTrollspo>().transform;
        impactPoint = UtilsClass.GetMouseWorldPos();
        Vector2 dir = (impactPoint -  new Vector2(transform.position.x, transform.position.y));
    }

    private void FixedUpdate()
    {
        spin += spinRate;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,spin));
        //Vector3 dirToPlayer = (playerT.position - transform.position).normalized;
        if (!reachedPoint)
        {
            float distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), impactPoint);
            transform.position = Vector3.SmoothDamp(transform.position, impactPoint, ref velocity, speedRateCast);
            if (distance < 0.5f)
            {
                reachedPoint = true;
            }
        }
        else
        {
            float distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), playerT.position);
            transform.position = Vector3.SmoothDamp(transform.position, playerT.position, ref velocity, speedRateReturn);
            if (distance < 1.5f)
            {
                Destroy(gameObject);
            }
        }
        
        // rb.AddForce();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hello");
            Destroy(gameObject);
        }
        else if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<IDamageable>().TakeDamage(1);   
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hello");
            Destroy(gameObject);
        }
        else if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<IDamageable>().TakeDamage(damage);   
        }
    }
}
