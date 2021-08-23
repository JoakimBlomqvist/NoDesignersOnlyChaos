using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int health;
    [SerializeField] private ParticleSystem blood;
    public UnityEvent OnDamageTaken;
    public void TakeDamage(int damage)
    {
        if (OnDamageTaken != null)
        {
            OnDamageTaken.Invoke();
        }
        
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Instantiate(blood, gameObject.transform.position, Quaternion.identity);
        
        gameObject.SetActive(false);
        
        
        Debug.Log("ded");
    }
}
