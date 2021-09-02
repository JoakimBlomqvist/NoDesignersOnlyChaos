using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityBody : MonoBehaviour
{
    public bool gravityOn;
    public FauxGravityAttractor attractor;
    public Rigidbody2D rb;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gravityOn)
        { attractor.Attract(transform); }
}

    private void OnTriggerEnter(Collider other)
    {
        attractor = other.gameObject.GetComponent<FauxGravityAttractor>();
        gravityOn = true;
    }
}
