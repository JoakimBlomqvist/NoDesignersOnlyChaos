using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FreezeAbility
{
    private List<Collider2D> _collider2Ds = new List<Collider2D>();
    
    
    public void FreezeAllEnemies(Vector3 origin, float radius, LayerMask layerMask)  
    {
        
        _collider2Ds = Physics2D.OverlapCircleAll(origin, radius, layerMask).ToList();
    }

    IEnumerator FreezeEnemies()
    {
        if (_collider2Ds.Count > 0)
        {
            for (int i = 0; i < _collider2Ds.Count; i++)
            {
                Debug.Log(i);
                GameObject enemyGameObject = _collider2Ds[i].gameObject;
                Debug.Log("Freezing " + enemyGameObject.name);
                Enemy enemy = enemyGameObject.GetComponent<Enemy>();
                if (enemyGameObject.GetComponent<SpriteRenderer>() != null)
                {
                    enemyGameObject.GetComponent<SpriteRenderer>().color = new Color(0, 1, 1);
                }
                if (enemy is BomberAi)
                {
                    enemyGameObject.GetComponent<BomberAi>().isFreezed = true;
                }
                else
                {
                    enemy.enabled = false;
                }

                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
