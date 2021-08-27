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
    public UnityEvent OnDeathEvent;
    [SerializeField]private bool clonedEnemy;
    public Action OnDeath;
    [Space(5)]
    [SerializeField]private AudioClip DeathAudioClip;
    [Range(0,1)]
    [SerializeField] private float DeathAudioVolume = 1;
    [Space(5)]
    [SerializeField] private AudioClip TakeDamageAudioClip;
    [Range(0,1)]
    [SerializeField] private float TakeDamageVolume = 1;
    
    private void Start()
    {
        maxHealth = health;
        EventManager.instance.OnChangeRoom += RegenHealthOnRoomChange;
        //HealthBar = GetComponent<Image>();
    }

    public void TakeDamage(int damage)
    {
        PlayTakeDamageSound();
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
        OnDeathEvent.Invoke();
        Instantiate(blood, gameObject.transform.position, Quaternion.identity);
        health = maxHealth;
        PlayDeathSound();
        gameObject.SetActive(false);
    }

    private void PlayDeathSound()
    {
        if (DeathAudioClip != null)
        {
            SFXManager.Instance.PlaySound(DeathAudioClip, DeathAudioVolume);
        }
    }

    private void PlayTakeDamageSound()
    {
        if (TakeDamageAudioClip != null)
        {
            SFXManager.Instance.PlaySound(TakeDamageAudioClip, TakeDamageVolume);
        }
    }
}
