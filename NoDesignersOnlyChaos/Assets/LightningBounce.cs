using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBounce : MonoBehaviour
{
    Rigidbody2D rb;

    Vector3 lastVelocity;


    [SerializeField] private int force;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 dir = (UtilsClass.GetMouseWorldPos() - new Vector2(transform.position.x, transform.position.y)).normalized;
        rb.AddForce(dir * force);
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        lastVelocity = rb.velocity;

    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collider.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(speed, 0f);
        

    }
    

    
}
