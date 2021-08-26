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
        KillCount.Instance.ResetRoomKillCount();
        
        StartCoroutine(AudioManager.Instance.InreasePitch());
        if (bossRoom)
        {
            Instantiate(bossToSpawn, spawnPoints[0].transform.position, Quaternion.identity);
            KillCount.Instance.spawnCount++;
            KillCount.Instance.RoomKillCount();
            return;
        }
        foreach (var spawn in spawnPoints)
        {
            var pool = ObjectPool.Instance.SpawnRandomFromPool(spawn.transform.position, quaternion.identity);
            if (RoomCurrency.Instance.Currency >= pool.Item2)
            {
                KillCount.Instance.spawnCount++;
                RoomCurrency.Instance.Currency -= pool.Item2;
                Debug.Log("Spawned: " + pool.Item1.name + " With a cost of " + pool.Item2);
            }
            else
            {
                Debug.Log("Tried to spawn " + pool.Item1.name);
                pool.Item1.SetActive(false);
            }
            
        }
        
        KillCount.Instance.RoomKillCount();
    }
}
