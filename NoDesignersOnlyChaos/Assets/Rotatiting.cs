using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Linq;
public class Rotatiting : MonoBehaviour
{
    private float spin;
    [SerializeField] private float spinrate;
    [SerializeField] private bool increaseSpinRate;
    [SerializeField,Range(0f,0.5f)] private float spinRateIncreaseAmount;
    [SerializeField] private float speed;
    private Vector3 randVector;
    private Vector3 mousePos;
    private bool reverse;
    
    private void Start()
    {
        Vector3 random = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), 0);
        Vector3.Normalize(random);
        randVector = random;
        transform.position = transform.position + randVector;
        mousePos = UtilsClass.GetMouseWorldPosV3();
        if (mousePos.x > PlayerManager.playerPosition.x)
        {
            reverse = true;
        }
    }

    private void FixedUpdate()
    {
        MovePos();
        IncreaseSpinRate();
        Spin();
    }

    private void IncreaseSpinRate()
    {
        if (increaseSpinRate)
        {
            spinrate += spinrate * spinRateIncreaseAmount;
        }
        
    }

    private void Spin()
    {
        if (reverse)
        {
            spin -= spinrate;
        }
        else
        {
            spin += spinrate;
        }
        transform.localRotation = quaternion.Euler(0,0,spin);
    }
    private void MovePos()
    {
        if (transform.position.x > transform.parent.position.x)
        {
            transform.position = transform.position + Vector3.right *Time.deltaTime * speed;
        }
        if (transform.position.x < transform.parent.position.x)
        {
            transform.position = transform.position - Vector3.right *Time.deltaTime * speed;
        }

    }
}
