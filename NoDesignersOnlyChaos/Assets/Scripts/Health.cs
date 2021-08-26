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
    private int maxHealth;
    [SerializeField] private int health;
    [SerializeField] private ParticleSystem blood;
    public UnityEvent OnDamageTaken;
    [SerializeField]private bool clonedEnemy;
    public Action OnDeath;


    private void Start()
    {
        maxHealth = health;
        //HealthBar = GetComponent<Image>();
    }

    public void TakeDamage(int damage)
    {

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
        
        if (OnDamageTaken != null)
        {
            OnDamageTaken.Invoke();
        }
    }

    public void Die()
    {
        if (!clonedEnemy)
        {
            EventManager.instance.Die();
        }
        Instantiate(blood, gameObject.transform.position, Quaternion.identity);
        health = maxHealth;
        gameObject.SetActive(false);
    }
}
