using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageOnContactTrigger : MonoBehaviour
{
    [SerializeField] private string tagToDamage;
    [SerializeField] private int damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(tagToDamage))
        {
            other.gameObject.GetComponent<IDamageable>().TakeDamage(damage);
        }
    }
}
