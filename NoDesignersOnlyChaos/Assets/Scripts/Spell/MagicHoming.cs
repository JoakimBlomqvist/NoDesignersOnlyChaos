using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class MagicHoming : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    public float rotateSpeed = 200f;
    [SerializeField] private float homingRadius = 3f;
    [SerializeField]private int force;
    [SerializeField] private List<Collider2D> targets;
    [SerializeField] private Collider2D target;
    public ContactFilter2D layer;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 dir = (UtilsClass.GetMouseWorldPos() - new Vector2(transform.position.x, transform.position.y)).normalized;
        rb.AddForce(dir * force);
        Destroy(gameObject, 10f);
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            Physics2D.OverlapCircle(transform.position, homingRadius, layer, targets);
        }
        
        if (targets != null && targets.Count != 0)
        {
            target = targets[0];
        }
        
        if (target != null)
        {
            
            Vector2 direction = (Vector2) target.transform.position - rb.position;
            
            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
