using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpermCharacter : Enemy
{
    public LayerMask targetLayer;
    public float moveSpeed = 2f;    
    private Collider2D Lockedtarget;
    private Rigidbody2D rb;
    private bool once = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    private void Update()
    {
        if(isFreezed)
            return;
        FindTarget();
        AttackTarget();
    }

    private void AttackTarget()
    {
        if (Lockedtarget != null)
        {
            if (!once)
            {
                Physics2D.IgnoreCollision(Lockedtarget, gameObject.GetComponent<Collider2D>());
                once = true;
            }

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

    private void FindTarget()
    {
        if (Lockedtarget == null)
        {
            Lockedtarget = Physics2D.OverlapCircle(transform.position, 8f, targetLayer);
        }
    }
}
