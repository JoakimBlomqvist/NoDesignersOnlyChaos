using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SuicideBomber : Enemy
{
    //private RaycastHit2D hit;
    [SerializeField] private float detectionRange;
    [SerializeField] private float moveSpeed;
    [SerializeField] private LayerMask playerLayer;
    private Rigidbody2D rb;
    [SerializeField] private float detectionFreq;
    private bool playerInSight;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(LookForPlayerRoutine());
    }

    private void Update()
    {
        if (playerInSight)
        {
            AttackTarget();
        }
    }

    private void FindTarget()
    {
        Vector2 dirToPlayer = (PlayerManager.Instance.playerPosition - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dirToPlayer, detectionRange, playerLayer, -1, 22);
        if (hit.collider.gameObject.layer == LayerMask.GetMask("Player"))
        {
            playerInSight = true;
            Debug.DrawRay(transform.position, dirToPlayer, Color.cyan, 1f);
        }
        else
        {
            Debug.Log("Player not in sight");
            playerInSight = false;
        }
    }
    private void AttackTarget()
    {
        Vector2 direction = PlayerManager.Instance.playerPosition - transform.position;
        rb.MovePosition(rb.position + direction.normalized * Time.deltaTime * moveSpeed);
    }

    IEnumerator LookForPlayerRoutine()
    {
        while (true)
        {
            FindTarget();
            yield return new WaitForSeconds(detectionFreq);
        }
    }
}
