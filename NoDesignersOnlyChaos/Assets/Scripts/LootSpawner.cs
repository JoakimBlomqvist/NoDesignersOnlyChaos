using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnPoints;
    [SerializeField]private bool bossRoom = false;
    [SerializeField] public GameObject bossToSpawn;

    public void SpawnLoot()
    {
        if (bossRoom)
        {
            Instantiate(bossToSpawn, spawnPoints[0].transform.position, Quaternion.identity);
            return;
        }
        foreach (var spawn in spawnPoints)
        {
            Debug.Log("Spawned");
            var pool = ObjectPool.Instance.SpawnRandomFromPool(spawn.transform.position, quaternion.identity);
            if (RoomCurrency.Instance.Currency >= pool.Item2)
            {
                RoomCurrency.Instance.Currency -= pool.Item2;    
            }
            else
            {
                pool.Item1.SetActive(false);
            }
            
        }
    }
}
