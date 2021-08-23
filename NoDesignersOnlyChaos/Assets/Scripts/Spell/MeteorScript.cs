using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeteorScript : SpellType
{
    private Vector2 impactPoint;
    private Vector2 newDir;
    [SerializeField] private float meteorSpeed;
    [SerializeField] private GameObject explosionPrefab;
    private void Start()
    {
        impactPoint = UtilsClass.GetMouseWorldPos();
        Vector2 dir = new Vector2(Random.Range(-0.8f, 0.8f), 1);
        transform.position = impactPoint +  dir*10;
        newDir = (impactPoint - new Vector2(transform.position.x,transform.position.y)).normalized;
    }

    private void FixedUpdate()
    {
        transform.localScale = transform.localScale * 0.94f;
        transform.position = new Vector3(transform.position.x + newDir.x* Time.fixedDeltaTime * meteorSpeed,
            transform.position.y + newDir.y* Time.fixedDeltaTime *meteorSpeed, transform.position.z);
        if (transform.position.y < impactPoint.y)
        {
            Explode();
            Destroy(gameObject);
        }
    }

    private void Explode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
}
