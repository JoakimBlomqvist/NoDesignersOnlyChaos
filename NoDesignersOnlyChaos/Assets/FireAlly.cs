using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAlly : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]private int force;
    [SerializeField]private GameObject explosion;
    private Collider2D Lockedtarget; 
    [SerializeField]private LayerMask targetLayer; 
    [SerializeField] private float moveSpeed;
    private void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 8);
        rb = GetComponent<Rigidbody2D>();
        Vector2 dir = (UtilsClass.GetMouseWorldPos() - new Vector2(transform.position.x, transform.position.y)).normalized;
        rb.AddForce(dir * force);
        Destroy(gameObject, 4f);
        StartCoroutine(CheckCooldown());
    }

    private void Update()
    {
        moveSpeed += Time.deltaTime * 5f;
        if (Lockedtarget == null)
        {
            Lockedtarget = Physics2D.OverlapCircle(transform.position, 12f, targetLayer);
        }
        
        if (Lockedtarget != null)
        {
            //moveSpeed += Time.deltaTime * 0.4f;
            var direction = Vector2.zero;
            
            direction = Lockedtarget.transform.position - transform.position;
            //rb.AddRelativeForce(direction.normalized * moveSpeed, ForceMode2D.Force);*/

            rb.MovePosition(rb.position + direction.normalized * Time.deltaTime * moveSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

    private IEnumerator CheckCooldown()
    {
        yield return new WaitForSeconds(2f);
        if (rb.velocity == Vector2.zero)
        {
            Destroy(gameObject);
        }
    }
}
