using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpell : MonoBehaviour
{
    [SerializeField] private GameObject spellProjectile;

    private void Start()
    {
        LeanTween.moveY(gameObject, gameObject.transform.position.y + 0.25f, 1f).setEaseLinear().setLoopPingPong();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerAimTrollspo>().projectilePrefab = spellProjectile;
            other.gameObject.GetComponent<PlayerAimTrollspo>().PickUp();
            Destroy(gameObject);
        }
    }
}
