using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpermBoss : MonoBehaviour
{
    private bool coolDown = false;
    [SerializeField]private GameObject spermPrefab;
    [SerializeField]private float secondsBetweenSpawn;
    private Rigidbody2D rb;
    [SerializeField]private float moveSpeed;
    private Vector2 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!coolDown)
        {
            StartCoroutine(SpawnSperm());
        }
        
        rb.MovePosition(rb.position + -direction * (Time.deltaTime * moveSpeed));
    }

    private IEnumerator SpawnSperm()
    {
        coolDown = true;
        Instantiate(spermPrefab, transform.position - new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f), quaternion.identity);
        direction = Vector2.zero;
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1, 1f), 0f) - transform.position;
        yield return new WaitForSeconds(secondsBetweenSpawn);
        coolDown = false;
    }
}
