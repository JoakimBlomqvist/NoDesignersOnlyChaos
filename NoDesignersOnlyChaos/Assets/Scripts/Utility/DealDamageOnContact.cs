using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageOnContact : MonoBehaviour
{
    [SerializeField] private string tagToDamage;
    [SerializeField] private int damage;
    [SerializeField] private bool destroyOnContact;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(tagToDamage))
        {
            other.gameObject.GetComponent<IDamageable>().TakeDamage(damage);
            if (destroyOnContact)
            {
                Destroy(gameObject);
            }
        }
    }
}
