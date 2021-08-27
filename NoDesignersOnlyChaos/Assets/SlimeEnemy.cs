using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SlimeEnemy : MonoBehaviour
{
    [SerializeField] GameObject SlimeToSpawn;
    private Rigidbody2D rb;
    [SerializeField]private float moveSpeed;
    private bool coolDown;
    private Vector2 direction;
    [SerializeField] private Transform player;
    private bool startChase;
    
    
    private void Start()
    {
        player = FindObjectOfType<PlayerAimTrollspo>().transform;
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnDeathSlime()
    {
        if (SlimeToSpawn != null)
        {
            Instantiate(SlimeToSpawn, transform.position, Quaternion.identity);
            Instantiate(SlimeToSpawn, transform.position, Quaternion.identity);
        }
    }

    private void Update()
    {
        
        if (!coolDown)
        {
                StartCoroutine(NewDirection());
        }

        rb.MovePosition(rb.position + direction.normalized * (Time.deltaTime * moveSpeed));
    }

    private IEnumerator NewDirection()
    {
        coolDown = true;
        direction = Vector2.zero;
        direction = player.transform.position - transform.position;
        yield return new WaitForSeconds(2f);
        coolDown = false;
    }
}
