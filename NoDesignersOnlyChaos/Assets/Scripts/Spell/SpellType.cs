using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellType : MonoBehaviour
{
    public GameObject projectilePrefab;
    [HideInInspector]
    public Transform TrollSpoT;
    [HideInInspector]
    public Collider2D playerCollider;
    
    public virtual void Shoot()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerAimTrollspo>().spellType = this;
            other.gameObject.GetComponent<PlayerAimTrollspo>().PickUp();
            gameObject.SetActive(false);
        }
    }
}
