using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stationary_AI : MonoBehaviour
{
    private Rigidbody2D rb;
    

    private void OnEnable()
    {
        if(rb == null)
            rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
