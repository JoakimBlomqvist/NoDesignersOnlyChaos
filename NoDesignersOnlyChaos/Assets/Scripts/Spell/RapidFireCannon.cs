using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFireCannon : SpellType
{
    public override void Shoot()
    {
        var projectile = Instantiate(projectilePrefab, new Vector3(TrollSpoT.position.x, TrollSpoT.position.y,0), Quaternion.identity);
        Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), playerCollider);
    }
}
