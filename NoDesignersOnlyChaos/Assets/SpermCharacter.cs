using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpermCharacter : MonoBehaviour
{
    public LayerMask targetLayer;
    public float moveSpeed = 2f;    
    private Collider2D Lockedtarget;
    private Rigidbody2D rb;
    [SerializeField] private string tagToDamage;
    [SerializeField] private int damage;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Lockedtarget == null)
        {
            Lockedtarget = Physics2D.OverlapCircle(transform.position, 8f, targetLayer);
        }

        if (Lockedtarget != null)
        {
            var direction = Vector2.zero;

            direction = Lockedtarget.transform.position - transform.position;
            if (Vector2.Distance(transform.position, Lockedtarget.transform.position) < 5f)
            {
                rb.AddRelativeForce(direction.normalized * moveSpeed, ForceMode2D.Force);
            }
            else
            {
                rb.velocity = direction * moveSpeed;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(tagToDamage))
        {
            other.gameObject.GetComponent<IDamageable>().TakeDamage(damage);
        }
    }
}
