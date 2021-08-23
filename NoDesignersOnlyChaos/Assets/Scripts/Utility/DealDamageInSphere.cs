using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageInSphere : MonoBehaviour
{
    [SerializeField] private string tagToDamage;
    [SerializeField] private int damage;
    [SerializeField] private float radius;

    private void Start()
    {
        SphereDamage();
    }

    public void SphereDamage()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, radius);
        for (int i = 0; i < collider2Ds.Length; i++)
        {
            if (collider2Ds[i].gameObject.CompareTag(tagToDamage))
            {
                collider2Ds[i].gameObject.GetComponent<IDamageable>().TakeDamage(damage);
            }            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,radius);
    }
}
