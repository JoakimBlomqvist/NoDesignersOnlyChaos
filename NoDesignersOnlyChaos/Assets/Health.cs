using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int health;
    [SerializeField] private ParticleSystem blood;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(blood, gameObject.transform.position, Quaternion.identity);

        Destroy(gameObject);
        
        
        Debug.Log("ded");
    }
}
