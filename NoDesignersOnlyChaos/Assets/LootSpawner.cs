using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnPoints;

    private void Start()
    {
        SpawnLoot();
    }

    public void SpawnLoot()
    {
        foreach (var spawn in spawnPoints)
        {
            Debug.Log("Spawned");
            ObjectPool.Instance.SpawnRandomFromPool(spawn.transform.position, quaternion.identity);
        }
    }
}
