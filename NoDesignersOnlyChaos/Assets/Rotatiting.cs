using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Rotatiting : MonoBehaviour
{
    private float spin;
    [SerializeField] private float spinrate;
    private void FixedUpdate()
    {
        spin += spinrate;
        transform.localRotation = quaternion.Euler(0,0,spin);
    }
}
