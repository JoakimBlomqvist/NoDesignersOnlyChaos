using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Bullet : MonoBehaviour
{
    [SerializeField] private float speed_bullet = 15;
    private Rigidbody2D rb;

    public static bool player_Alive = false;
    CharacterMovement characterMovement;
    Vector2 moveDir;
    Vector3 lastVelocity;
    // Start is called before the first frame update
    [SerializeField]
    private void Awake()
    {
        
        characterMovement = GameObject.FindObjectOfType<CharacterMovement>();
        rb = GetComponent<Rigidbody2D>();
        
        moveDir = (characterMovement.transform.position - transform.position).normalized * speed_bullet;
        rb.AddForce(moveDir * speed_bullet);

        Destroy(gameObject, 5f);
        
    }

    private void Update()
    {
        lastVelocity = rb.velocity;
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collider.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0f);
        characterMovement = collider.collider.GetComponent<CharacterMovement>();
        if (collider != null)
        {
            Destroy(characterMovement);
            player_Alive = true;
        }
    }
}
