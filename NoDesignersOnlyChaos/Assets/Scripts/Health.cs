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
    [SerializeField]private AudioClip DeathAudioClip;

    private void OnEnable()
    {
        
    }

    private void Start()
    {
        maxHealth = health;
        EventManager.instance.OnChangeRoom += RegenHealthOnRoomChange;
        //HealthBar = GetComponent<Image>();
    }

    public void TakeDamage(int damage)
    {

        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        UpdateHealthFillAMount();
        
        if (OnDamageTaken != null)
        {
            OnDamageTaken.Invoke();
        }
    }

    private void UpdateHealthFillAMount()
    {
        if (HealthBar != null)
        {
            CurrentHealth = health;
            HealthBar.fillAmount = CurrentHealth / maxHealth;
        }
    }

    private void RegenHealthOnRoomChange()
    {
        health = Mathf.Clamp(health + 5, -1, maxHealth);
        UpdateHealthFillAMount();
    }

    public void Die()
    {
        if (!clonedEnemy)
        {
            EventManager.instance.Die();
        }
        Instantiate(blood, gameObject.transform.position, Quaternion.identity);
        health = maxHealth;
        PlayDeathSound();
        gameObject.SetActive(false);
    }

    private void PlayDeathSound()
    {
        if (DeathAudioClip != null)
        {
            SFXManager.Instance.PlaySound(DeathAudioClip);
        }
    }
}
