using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField]private float time = 1f;

    [Space(5f)]
    [SerializeField] private bool randomizeTime;
    [SerializeField] private float randTimeMin;
    [SerializeField] private float randTimeMax;

    void Start()
    {
        DestroySelf();
    }

    private void DestroySelf()
    {
        if (randomizeTime)
        {
            float value = Random.Range(randTimeMin, randTimeMax);
            Destroy(gameObject, time + value);
        }
        else
        {
            Destroy(gameObject, time);
        }
    }
    
}
