using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnPoints;

    public void SpawnLoot()
    {
        foreach (var spawn in spawnPoints)
        {
            Debug.Log("Spawned");
            var pool = ObjectPool.Instance.SpawnRandomFromPool(spawn.transform.position, quaternion.identity);
        }
    }
}
