using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FreezeAbility : PassiveAbility
{
    private List<Collider2D> _collider2Ds;
    [SerializeField] private LayerMask enemyLayer;
    private Transform target;
    [SerializeField] private float freezeTime;
    public override void UseAbility()
    {
        StartCoroutine(FreezeTarget());
    }

    IEnumerator FreezeTarget()
    {
        _collider2Ds = Physics2D.OverlapCircleAll(PlayerManager.Instance.playerPosition, range, enemyLayer).ToList();
        if (_collider2Ds.Count > 0)
        {
            target = _collider2Ds[Random.Range(0, _collider2Ds.Count)].transform;
            if (target.GetComponent<Enemy>() == null)
                yield return null;
            Enemy enemy = target.GetComponent<Enemy>();
            
            enemy.isFreezed = true;
            if (enemy.GetComponent<SpriteRenderer>() != null)
            {
                enemy.GetComponent<SpriteRenderer>().color = new Color(0, 1, 1);
            }
            yield return new WaitForSeconds(freezeTime);
            if (enemy.GetComponent<SpriteRenderer>() != null)
            {
                enemy.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            }
            enemy.isFreezed = false;
        }
    }
}
