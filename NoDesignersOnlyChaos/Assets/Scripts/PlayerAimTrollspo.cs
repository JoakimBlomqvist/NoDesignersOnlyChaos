using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Diagnostics;

public class PlayerAimTrollspo : MonoBehaviour
{
    private Vector3 worldPosition;
    [SerializeField] private Transform TrollSpoT;
    private SpriteRenderer _spriteRenderer;
    public SpellType spellType;
    public GameObject projectilePrefab;
    public bool rapidFire = false;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        spellType.projectilePrefab = projectilePrefab;
        spellType.TrollSpoT = TrollSpoT;
        spellType.playerCollider = GetComponent<Collider2D>();
    }
    /*
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            spellType = other.gameObject.GetComponent<SpellType>();
            PickUp();
            Destroy(other.gameObject);
        }
    }
    */
    [ContextMenu("Pick up")]
    public void PickUp()
    {
        spellType.projectilePrefab = projectilePrefab;
        spellType.TrollSpoT = TrollSpoT;
        spellType.playerCollider = GetComponent<Collider2D>();
        rapidFire = spellType.rapidFire;
    }

    void Update()
    {
        switch (rapidFire)
        {
            case false:
                if (Input.GetMouseButtonDown(0))
                {
                    spellType.Shoot();
                }
                break;
            
            case true:
                if (Input.GetMouseButton(0))
                {
                    spellType.Shoot();
                }
                break;
        }

        Vector3 aimDir = (UtilsClass.GetMouseWorldPosV3() - transform.position).normalized;
        TrollSpoT.position = transform.position + aimDir;
        TrollSpoT.LookAt(UtilsClass.GetMouseWorldPosV3());
        FlipCharacterSprite();
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
}
