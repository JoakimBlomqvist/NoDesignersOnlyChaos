using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidBall : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    public float rotateSpeed = 200f;
    [SerializeField] private float homingRadius = 3f;
    [SerializeField]private int force;
    [SerializeField] private Collider2D target;
    public LayerMask layer = 6;
    private bool ok = false;
    private float spin;
    private Vector2 direction;
    [SerializeField] private float WaitTilSpinSeconds;
    
    [Header("Damage On Contact")]
    [SerializeField] private string tagToDamage;
    [SerializeField] private int damage;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 dir = (UtilsClass.GetMouseWorldPos() - new Vector2(transform.position.x, transform.position.y)).normalized;
        rb.AddForce(dir * force);
        Destroy(gameObject, 5f);
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            target = Physics2D.OverlapCircle(transform.position, homingRadius, layer);
        }

        if (target != null)
        {
            StartCoroutine(WaitTilSpin());
            if (!ok) return;
            direction = (Vector2) target.transform.position - rb.position;
            
            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(tagToDamage))
        {
            other.gameObject.GetComponent<IDamageable>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    IEnumerator WaitTilSpin()
    {
        yield return new WaitForSeconds(WaitTilSpinSeconds);
        ok = true;
    }
}
