using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Diagnostics;

public class PlayerAimTrollspo : MonoBehaviour
{
    [SerializeField] private SpriteRenderer stavSprite;
    [SerializeField] private Animator staffAnimator;
    private Vector3 worldPosition;
    [SerializeField]private Transform TrollSpoT;
    private SpriteRenderer _spriteRenderer;
    public SpellType spellType;
    public GameObject projectilePrefab;
    public bool rapidFire = false;
    public FloatVariable rateOfFire;
    public UltimateAbility ultimate;
    public Health playerHealth;
    private float fireRateTimer = 0;

    #region Subscriptions

    private void OnEnable()
    {
        EventManager.instance.OnSetUltimate += GetUltimate;
        EventManager.instance.OnSetPassiveUlt += GetPassiveUlt;
    }
    
    private void OnDisable()
    {
        EventManager.instance.OnSetUltimate -= GetUltimate;
        EventManager.instance.OnSetPassiveUlt -= GetPassiveUlt;
    }

    #endregion

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        spellType.projectilePrefab = projectilePrefab;
        spellType.TrollSpoT = TrollSpoT;
        spellType.playerCollider = GetComponent<Collider2D>();
        rateOfFire.SetValue(spellType.rateOfFire);
    }

    [ContextMenu("Pick up")]
    public void PickUp()
    {
        spellType.projectilePrefab = projectilePrefab;
        TrollSpoT.transform.localScale = spellType.TrollSpoT.localScale;
        spellType.TrollSpoT = TrollSpoT;
        spellType.playerCollider = GetComponent<Collider2D>();
        rapidFire = spellType.rapidFire;
        staffAnimator.runtimeAnimatorController = spellType.anim;
        stavSprite.sprite = spellType.staffSprite;
    }

    void Update()
    {
        WaitForNextShot();

        Vector3 aimDir = (UtilsClass.GetMouseWorldPosV3() - transform.position).normalized;
        TrollSpoT.position = transform.position + aimDir;
        TrollSpoT.LookAt(UtilsClass.GetMouseWorldPosV3());
        FlipCharacterSprite();
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            Ultimate();
        }
    }

    private void WaitForNextShot()
    {
        fireRateTimer += Time.deltaTime;
        if (fireRateTimer > rateOfFire.Value)
        {
            if (Input.GetMouseButton(0))
            {
                spellType.Shoot();
                fireRateTimer = 0;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            fireRateTimer = rateOfFire.Value;
        }
    }

    private void Ultimate()
    {
        if (ultimate != null)
        {
            ultimate.UseUltimate();
        }
    }
    
    private void FlipCharacterSprite()
    {
        if (TrollSpoT.position.x > transform.position.x && _spriteRenderer.flipX == true)
        {
            _spriteRenderer.flipX = false;
        }
        else if(TrollSpoT.position.x < transform.position.x && _spriteRenderer.flipX == false)
        {
            _spriteRenderer.flipX = true;
        }
    }

    public void Shoot()
    {
        var projectile = Instantiate(projectilePrefab, new Vector3(TrollSpoT.position.x, TrollSpoT.position.y,0), quaternion.identity);
        Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private void GetUltimate(UltimateAbility ult)
    {
        ultimate = ult;
        ultimate.enabled = true;
    }

    private void GetPassiveUlt(string ultName)
    {
        switch (ultName)
        {
            case "Revive":
                playerHealth.ressUltimate = true;
                break;
        }
    }
}
