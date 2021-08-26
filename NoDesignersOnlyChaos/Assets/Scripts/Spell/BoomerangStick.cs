using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class BoomerangStick : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 impactPoint;
    private Vector2 startPoint;
    [SerializeField] private int force;
    private Transform playerT;
    private int spin;

    private Vector3 velocity;

    private bool reachedPoint;
    
    void Start()
    {
        playerT = FindObjectOfType<PlayerAimTrollspo>().transform;
        rb = GetComponent<Rigidbody2D>();
        impactPoint = UtilsClass.GetMouseWorldPos();
        Vector2 dir = (impactPoint -  new Vector2(transform.position.x, transform.position.y));
        rb.AddForce(dir*force);
    }

    private void FixedUpdate()
    {
        spin += 10;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,spin));
        float distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), impactPoint);

        //Vector3 dirToPlayer = (playerT.position - transform.position).normalized;
        if (!reachedPoint)
        {
            transform.position = Vector3.SmoothDamp(transform.position, impactPoint, ref velocity, 0.5f);
            if (distance < 0.5f)
            {
                reachedPoint = true;
            }
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, playerT.position, ref velocity, 0.5f);
        }
        
        // rb.AddForce();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
