using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]private int force;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 dir = (UtilsClass.GetMouseWorldPos() - new Vector2(transform.position.x, transform.position.y)).normalized;
        rb.AddForce(dir * force);
        Destroy(gameObject, 10f);
    }
}
