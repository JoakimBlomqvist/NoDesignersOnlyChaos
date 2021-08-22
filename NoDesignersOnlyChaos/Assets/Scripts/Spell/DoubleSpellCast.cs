using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSpellCast : SpellType
{
    public override void Shoot()
    {
        var projectile = Instantiate(projectilePrefab, new Vector3(TrollSpoT.position.x, TrollSpoT.position.y,0), Quaternion.identity);
        Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), playerCollider);
        var projectile2 = Instantiate(projectilePrefab, new Vector3(TrollSpoT.position.x, TrollSpoT.position.y+1,0), Quaternion.identity);
        Physics2D.IgnoreCollision(projectile2.GetComponent<Collider2D>(), playerCollider);
        Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), projectile2.GetComponent<Collider2D>());
    }
}
