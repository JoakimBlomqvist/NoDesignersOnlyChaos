using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] public Image HealthBar;
    public float CurrentHealth;
    private float maxHealth;
    [SerializeField] private int health;
    [SerializeField] private ParticleSystem blood;
    public UnityEvent OnDamageTaken;
    public Action OnDeath;


    private void Start()
    {
        maxHealth = health;
        //HealthBar = GetComponent<Image>();
    }

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
        if (HealthBar != null)
        {
            CurrentHealth = health;
            HealthBar.fillAmount = CurrentHealth / maxHealth;
        }
    }

    public void Die()
    {
        EventManager.instance.Die();
        Instantiate(blood, gameObject.transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
