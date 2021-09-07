using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class LightningAbility : PassiveAbility
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float damage;
    private List<Collider2D> _collider2Ds;
    [SerializeField] private LayerMask enemyLayer;
    private Transform target;

    [ContextMenu("StartPassiveLightning")]
    public override void UseAbility()
    {
        SpawnLightning();
    }
    private void SpawnLightning()
    {
        _collider2Ds = Physics2D.OverlapCircleAll(PlayerManager.Instance.playerPosition, range, enemyLayer).ToList();
        if (_collider2Ds.Count > 0)
        {
            target = _collider2Ds[Random.Range(0, _collider2Ds.Count)].transform;
            GameObject obj = Instantiate(prefab, PlayerManager.Instance.playerPosition, quaternion.identity);
            ZapAbilityParticle particle = obj.GetComponent<ZapAbilityParticle>();
            particle.target = target;
            particle.damage = damage;
        }
    }
}