using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinChase : MonoBehaviour
{
    public LayerMask targetLayer;
    public float moveSpeed = 2f;    
    private Collider2D Lockedtarget;
    private Rigidbody2D rb;
    private bool startChase;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        startChase = false;
        StartCoroutine(WaitTilchase());
    }

    void Update()
    {
        if (Lockedtarget == null && startChase)
        {
            Lockedtarget = Physics2D.OverlapCircle(transform.position, 8f, targetLayer);
        }
        
        if (Lockedtarget != null)
        {
            var direction = Vector2.zero;
            
            direction = Lockedtarget.transform.position - transform.position;
            //rb.AddRelativeForce(direction.normalized * moveSpeed, ForceMode2D.Force);*/

            rb.MovePosition(rb.position + direction.normalized * Time.deltaTime * moveSpeed);
        }
    }

    private IEnumerator WaitTilchase()
    {
        yield return new WaitForSeconds(1f);
        startChase = true;
    }
}
