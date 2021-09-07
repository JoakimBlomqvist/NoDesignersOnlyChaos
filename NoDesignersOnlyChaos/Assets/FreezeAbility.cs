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
                return;
            Enemy enemy = target.GetComponent<Enemy>();
            enemy.isFreezed = true;
            yield return new WaitForSeconds(freezeTime);
            enemy.isFreezed = false;
        }
    }
}
