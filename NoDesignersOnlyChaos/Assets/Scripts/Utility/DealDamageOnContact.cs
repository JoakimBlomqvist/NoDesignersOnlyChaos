using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageOnContact : MonoBehaviour
{
    [SerializeField] private string tag;
    [SerializeField] private int damage;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(tag))
        {
            other.gameObject.GetComponent<IDamageable>().TakeDamage(damage);
        }
    }
}
