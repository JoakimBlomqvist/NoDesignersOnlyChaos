using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberAi : Enemy
{
    Rigidbody2D rb;
    [SerializeField] private float dropRate = 0.7f;
    [SerializeField] private float delaytilDrop = 1f;
    private Coroutine bombRoutine;

    Vector3 lastVelocity;
    [SerializeField] private GameObject Bomb;

    [SerializeField] private int force;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartBombRoutine();
        StartCoroutine(ChangeMoveDirection());

        //lastVelocity = rb.velocity;
    }
    private void ChangeDir()
    {
        Vector2 dir = /*(Vector2)transform.position + */new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
        if (Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y) < 9f)
        {
            rb.AddForce(dir * force);
        }
        
    }

    IEnumerator ChangeMoveDirection()
    {
        while (true)
        {
            if (!isFreezed)
            {
                ChangeDir();
            }
            yield return new WaitForSeconds(5f);
        }
        
    }
    private void Update()
    {
        lastVelocity = rb.velocity;
        
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        //var player = collider.gameObject.CompareTag("player");
        
        if (collider.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collider.gameObject.GetComponent<Collider2D>() , gameObject.GetComponent<Collider2D>());
            return;
        }
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collider.contacts[0].normal);

        
        rb.velocity = direction * Mathf.Max(speed, 0f);
    }

    public void StopDropping()
    {
        if(bombRoutine != null)
        {
            StopCoroutine(bombRoutine);
            CancelInvoke("StartBombRoutine");
            CancelInvoke("ChangeDir");
        }
    }

    private void StartBombRoutine()
    {
        if (gameObject.activeSelf)
        {
            bombRoutine = StartCoroutine(BombDropping());
        }
    }
    IEnumerator BombDropping()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            if (!isFreezed)
            {
                var bomb = Instantiate(Bomb, transform.position, Quaternion.identity);
                Physics2D.IgnoreCollision(bomb.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
            }
            yield return new WaitForSeconds(dropRate);
        }
    }
}
