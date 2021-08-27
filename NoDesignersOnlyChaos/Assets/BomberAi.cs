using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberAi : MonoBehaviour
{
    Rigidbody2D rb;

    Vector3 lastVelocity;
    [SerializeField] private GameObject Bomb;
    
    [SerializeField] private int force;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 dir = (new Vector2(transform.position.x, transform.position.y)).normalized;
        rb.AddForce(dir * force);
        StartCoroutine(BombDropping());
        //lastVelocity = rb.velocity;
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

        
        StartCoroutine(BombDropping());

        //StartCoroutine(BombDropping());
    }
    IEnumerator BombDropping()
    {
        yield return new WaitForSeconds(3f);

        var bomb = Instantiate(Bomb, gameObject.transform.position, Quaternion.identity);
        Physics2D.IgnoreCollision(bomb.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        
        yield break;
    }
}
