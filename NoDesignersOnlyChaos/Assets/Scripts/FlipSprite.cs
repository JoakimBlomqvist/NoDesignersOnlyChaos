using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    [Tooltip("Flip this transform in relation to 'player transform' on the x axis")]
    private Transform playerTransfrom;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        playerTransfrom = PlayerManager.Instance.playerTransform;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (transform.position.x > playerTransfrom.position.x && _spriteRenderer.flipX == true)
        {
            _spriteRenderer.flipX = false;
        }
        else if (transform.position.x < playerTransfrom.position.x && _spriteRenderer.flipX == false)
        {
            _spriteRenderer.flipX = true;
        }
    }
}
