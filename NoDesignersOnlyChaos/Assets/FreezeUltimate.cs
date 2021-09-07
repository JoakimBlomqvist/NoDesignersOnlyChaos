using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FreezeUltimate : UltimateAbility
{
    private List<Collider2D> _collider2Ds = new List<Collider2D>();
    [SerializeField]private LayerMask enemyLayer;
    [SerializeField]private float radius;
    [SerializeField] private float freezeTime;
    [SerializeField] private GameObject particles;
    public override void UseAbility()
    {
        Debug.Log("Freezing");
        FreezeAllEnemies();
    }
    public void FreezeAllEnemies()
    {
        Instantiate(particles, PlayerManager.Instance.playerPosition, Quaternion.identity);
        _collider2Ds = Physics2D.OverlapCircleAll(PlayerManager.Instance.playerPosition, radius, enemyLayer).ToList();
        StartCoroutine(FreezeEnemies());
    }

    IEnumerator FreezeEnemies()
    {
        if (_collider2Ds.Count > 0)
        {
            for (int i = 0; i < _collider2Ds.Count; i++)
            {
                GameObject enemyGameObject = _collider2Ds[i].gameObject;
                if (enemyGameObject.GetComponent<Enemy>() == null)
                    continue;
                Enemy enemy = enemyGameObject.GetComponent<Enemy>();
                if (enemyGameObject.GetComponent<SpriteRenderer>() != null)
                {
                    enemyGameObject.GetComponent<SpriteRenderer>().color = new Color(0, 1, 1);
                }
                enemy.isFreezed = true;
                yield return new WaitForSeconds(0.01f);
            }

            yield return new WaitForSeconds(freezeTime);
            UnfreezeEnemies();
        }
    }
    private void UnfreezeEnemies()
    {
        for (int i = 0; i < _collider2Ds.Count; i++)
        {
            GameObject enemyGameObject = _collider2Ds[i].gameObject;
            if (enemyGameObject.GetComponent<Enemy>() == null)
                continue;
            Enemy enemy = enemyGameObject.GetComponent<Enemy>();
            if (enemyGameObject.GetComponent<SpriteRenderer>() != null)
            {
                enemyGameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            }
            enemy.isFreezed = false;
        }
    }

}
