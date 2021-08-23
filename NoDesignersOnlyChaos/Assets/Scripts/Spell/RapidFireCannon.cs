using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFireCannon : SpellType
{
    private bool allowFire = true;
    private void Start()
    {
        rapidFire = true;
    }

    public override void Shoot()
    {
        if (allowFire)
        {
            StartCoroutine(FireRate());
        }
    }

    private IEnumerator FireRate()
    {
        allowFire = false;
        var projectile = Instantiate(projectilePrefab, new Vector3(TrollSpoT.position.x, TrollSpoT.position.y,0), Quaternion.identity);
        Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), playerCollider);
        yield return new WaitForSeconds(0.08f);
        allowFire = true;
    }
}
