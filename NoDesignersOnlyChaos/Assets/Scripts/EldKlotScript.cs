using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EldKlotScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 dir = (UtilsClass.GetMouseWorldPos() - transform.position).normalized;
        rb.AddForce(dir * 1000);
        Destroy(gameObject, 10f);
    }
}
