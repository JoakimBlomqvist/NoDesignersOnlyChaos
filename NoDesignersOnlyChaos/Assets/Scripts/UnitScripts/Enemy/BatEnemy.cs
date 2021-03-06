using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEnemy : Enemy
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
        if(isFreezed)
            return;
        FindTarget();
        AttackTarget();
    }

    private void AttackTarget()
    {
        if (Lockedtarget != null)
        {
            var direction = Vector2.zero;
            direction = Lockedtarget.transform.position - transform.position;
            float speedMod = Vector3.Distance(Lockedtarget.transform.position, transform.position) * 0.4f;
            rb.AddRelativeForce(direction.normalized * moveSpeed * speedMod, ForceMode2D.Force);
        }
    }

    private void FindTarget()
    {
        if (Lockedtarget == null)
        {
            Lockedtarget = Physics2D.OverlapCircle(transform.position, 8f, targetLayer);
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
