using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimTrollspo : MonoBehaviour
{
    private Vector3 worldPosition;
    [SerializeField] private Transform TrollSpoT;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 mousePos = GetMouseWorldPos();
        Vector3 aimDir = (mousePos - transform.position).normalized;
        TrollSpoT.position = transform.position + aimDir;
        FlipCharacterSprite();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        return worldPosition;
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
}
