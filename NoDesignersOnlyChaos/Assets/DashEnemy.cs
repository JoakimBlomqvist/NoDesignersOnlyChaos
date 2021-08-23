using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private List<Collider2D> targets;
    private Collider2D Lockedtarget;
    [SerializeField] private float dashStrength = 4f;
    [SerializeField] private LayerMask targetLayer = 7;
    private bool allowDash = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Lockedtarget == null)
        {
            Lockedtarget = Physics2D.OverlapCircle(transform.position, 8f, targetLayer);
        }

        if (Lockedtarget != null)
        {
            if (allowDash)
            {
                StartCoroutine(DashCooldown());
                StartCoroutine(DashTowards());
            }
        }
    }

    private IEnumerator DashTowards()
    {
        Vector2 direction = (Vector2) Lockedtarget.transform.position - rb.position;
        
        rb.AddRelativeForce(direction * dashStrength);
        
        yield return new WaitForSeconds(0.5f);

        rb.velocity = Vector2.zero;
    }

    private IEnumerator DashCooldown()
    {
        allowDash = false;
        yield return new WaitForSeconds(2f);
        allowDash = true;
    }
}
