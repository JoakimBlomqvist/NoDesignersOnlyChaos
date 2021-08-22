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

    [SerializeField]private GameObject projectilePrefab;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        Vector3 aimDir = (UtilsClass.GetMouseWorldPos() - transform.position).normalized;
        TrollSpoT.position = transform.position + aimDir;
        TrollSpoT.LookAt(UtilsClass.GetMouseWorldPos());
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

    private void Shoot()
    {
        Instantiate(projectilePrefab, TrollSpoT.position, quaternion.identity);
    }
}
