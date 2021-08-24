using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBlast : MonoBehaviour
{
    [SerializeField] private float speed_Sunblast = 150;
    private Rigidbody2D rb;

    
    CharacterMovement characterMovement;
    Vector2 moveDir;
    Vector3 lastVelocity;
    // Start is called before the first frame update
    [SerializeField]
    private void Awake()
    {

        characterMovement = GameObject.FindObjectOfType<CharacterMovement>();
        rb = GetComponent<Rigidbody2D>();
        if (characterMovement != null)
        {
            moveDir = (characterMovement.transform.position - transform.position).normalized * speed_Sunblast;
            rb.AddForce(moveDir * speed_Sunblast);
        }


        Destroy(gameObject, 5f);

    }

    private void Update()
    {
        lastVelocity = rb.velocity;

    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        
        characterMovement = collider.collider.GetComponent<CharacterMovement>();
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<IDamageable>().TakeDamage(20);
            
        }
        Destroy(gameObject);
    }
}
