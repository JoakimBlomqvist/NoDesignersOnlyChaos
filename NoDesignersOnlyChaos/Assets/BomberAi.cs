using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberAi : MonoBehaviour
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

        changeDir();
        InvokeRepeating("StartBombRoutine", delaytilDrop, dropRate);
        InvokeRepeating("changeDir", 2f, 2f);
        
        //lastVelocity = rb.velocity;
    }
    private void changeDir()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 dir = /*(Vector2)transform.position + */new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));

        rb.AddForce(dir * force);
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
            CancelInvoke("changeDir");
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

        var bomb = Instantiate(Bomb, transform.position, Quaternion.identity);
        Physics2D.IgnoreCollision(bomb.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());

    }
}
