using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAi_Script : MonoBehaviour
{
    Vector3 lastVelocity;
    [SerializeField] private GameObject Bomb_Explosion;
    private Rigidbody2D rb;
    [SerializeField] private int force = 300;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 dir = (new Vector2(Random.Range(-4,4), Random.Range(-4,4)));
        rb.AddForce(dir * force);

        StartCoroutine(BombGoesBoom());
    }
    private void Update()
    {
        lastVelocity = rb.velocity;
    }
    IEnumerator BombGoesBoom()
    {
        
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
        Instantiate(Bomb_Explosion, gameObject.transform.position, Quaternion.identity);
        yield break;
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            //Physics2D.IgnoreCollision(collider.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
            Destroy(gameObject);
            Instantiate(Bomb_Explosion, gameObject.transform.position, Quaternion.identity);
        }
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collider.contacts[0].normal);


        rb.velocity = direction * Mathf.Max(speed, 0f);
    }
}
