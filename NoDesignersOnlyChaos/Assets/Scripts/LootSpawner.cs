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
    [SerializeField] private List<GameObject> spawnedEnemies;

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
            
            if (RoomCurrency.Instance.Currency >= pool.Item2 && !spawnedEnemies.Contains(pool.Item1))
            {
                KillCount.Instance.spawnCount++;
                RoomCurrency.Instance.Currency -= pool.Item2;
                spawnedEnemies.Add(pool.Item1);
                //Debug.Log("Spawned: " + pool.Item1.name + " With a cost of " + pool.Item2);
            }
            else if(spawnedEnemies.Contains(pool.Item1))
            {
                //Debug.Log("Tried to spawn " + pool.Item1.name);
                //Do nothing because the enemy has already been spawned from the object pool.
            }
            else
            {
                    //Debug.Log("Set spawned false " + pool.Item1.name);
                    pool.Item1.SetActive(false);
            }
        }
        
        spawnedEnemies.Clear();
        
        KillCount.Instance.RoomKillCount();
    }
}
