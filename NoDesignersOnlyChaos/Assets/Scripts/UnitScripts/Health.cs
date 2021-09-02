using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private GameObject RessObject;
    [SerializeField] public Image HealthBar;
    private float maxHealth;
    private float maxShield;
    [SerializeField] public Image ShieldBar;
    [SerializeField] private float Shield;
    [SerializeField] private float health;
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
    public bool ressUltimate;
    [SerializeField] private bool player;
    [SerializeField] private float buffedMaxHp;
    [SerializeField] private float buffedHP;
    [SerializeField] private float cameraShakeAmount;
    [SerializeField] private Rigidbody2D rb;
    private void Awake()
    {
        //Bool for RessUltimate if its true you get 1 more extra health
        
        //till för shield janne
        maxShield = Shield;

        maxHealth = health;
        if (player)
        {
            EventManager.instance.OnChangeRoom += RegenHealthOnRoomChange;
        }

        //HealthBar = GetComponent<Image>();
    }

    private void OnEnable()
    {
        if (!player)
        {
            buffedMaxHp += EnemyDifficultyManager.instance.buffedHP;
            buffedHP = maxHealth;
            buffedHP += buffedMaxHp;
            health = buffedHP;
            maxHealth = health;
            buffedHP -= buffedMaxHp;
            buffedMaxHp = 0;
        }
    }

    public void TakeDamage(float damage)
    {
        PlayTakeDamageSound();
        Shield -= damage;
        if(Shield <= 0)
        {
            health -= damage;
        }
        UpdateShieldFillAMount();
        if (health <= 0)
        {
            if (ressUltimate == true)
            {
                rb = GetComponent<Rigidbody2D>();
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                Instantiate(RessObject, transform.position, Quaternion.identity);
                Invoke("unfreezeChar", 3f);
                health = maxHealth;
                ressUltimate = false;
            }
            else
            {
                Die();
            }
            
        }
        UpdateHealthFillAMount();
        
        if (OnDamageTaken != null)
        {
            OnDamageTaken.Invoke();
        }
        CameraController.Instance.ShakeCamera(damage);
    }

    private void UpdateHealthFillAMount()
    {
        if (HealthBar != null)
        {
            HealthBar.fillAmount = health / maxHealth;
        }
    }
    private void UpdateShieldFillAMount()
    {
        if (ShieldBar != null)
        {
            ShieldBar.fillAmount = Shield / maxShield;
        }
    }
    private void RegenHealthOnRoomChange()
    {
        if (RoomCurrency.Instance.roomCounter % 3 == 0)
        {
            Shield = maxShield;
            UpdateShieldFillAMount();
        }

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
            SFXManager.Instance.PlaySound(DeathAudioClip);
        }
    }

    private void PlayTakeDamageSound()
    {
        if (TakeDamageAudioClip != null)
        {
            SFXManager.Instance.PlaySound(TakeDamageAudioClip);
        }
    }
    private void unfreezeChar()
    {
        rb.constraints = RigidbodyConstraints2D.None;
    }
}
