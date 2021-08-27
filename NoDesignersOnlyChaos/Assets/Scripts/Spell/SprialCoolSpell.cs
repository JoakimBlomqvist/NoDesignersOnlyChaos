using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using Random = UnityEngine.Random;

public class SprialCoolSpell : MonoBehaviour
{
    private float spin;
    [SerializeField] private float spinrate;
    private Vector3 randVector;
    [SerializeField] private float speed;
    private Transform playerT;
    private Vector3 mousePos;
    private bool reverse;
    private void Start()
    {
        playerT = FindObjectOfType<PlayerAimTrollspo>().transform;
        //transform.parent.position = playerT.position;
        mousePos = UtilsClass.GetMouseWorldPosV3();
        Vector3 dir = (mousePos - playerT.position).normalized;
        transform.position = playerT.position + dir * 2;
        Debug.Log(dir);
        if (mousePos.x > playerT.transform.position.x)
        {
            reverse = true;
        }
    }

    private void FixedUpdate()
    {
        if (reverse)
        {
            spin -= spinrate;
        }
        else
        {spin += spinrate;
            
        }
        
        transform.localRotation = Quaternion.Euler(0,0,spin);
    }
}
