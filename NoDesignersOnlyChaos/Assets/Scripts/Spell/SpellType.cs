using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellType : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Sprite staffSprite;
    public RuntimeAnimatorController anim;
    public Transform TrollSpoT;
    [HideInInspector]
    public Collider2D playerCollider;
    public float rateOfFire;
    public bool rapidFire = false;
    
    public virtual void Shoot()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerAimTrollspo>().rateOfFire.Value = rateOfFire;
            other.gameObject.GetComponent<PlayerAimTrollspo>().spellType = this;
            other.gameObject.GetComponent<PlayerAimTrollspo>().PickUp();
            gameObject.SetActive(false);
        }
    }
}
