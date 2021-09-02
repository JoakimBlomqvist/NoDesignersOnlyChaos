using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityAttractor : MonoBehaviour
{
    public float gravity = -9.81f;
    [SerializeField] private List<Collider2D> pullingEnemies;
    [SerializeField] private ContactFilter2D targetLayer;
    private Rigidbody2D enemyrb;

    private void Update()
    {
        Physics2D.OverlapCircle(transform.position, 10f, targetLayer, pullingEnemies);
        foreach (var enemy in pullingEnemies)
        {
            Attract(enemy.transform);
        }
    }

    public void Attract(Transform body)
    {
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;

        enemyrb = body.GetComponent<Rigidbody2D>();
        enemyrb.velocity = Vector2.zero;
        enemyrb.AddForce(gravityUp * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
    }
}
