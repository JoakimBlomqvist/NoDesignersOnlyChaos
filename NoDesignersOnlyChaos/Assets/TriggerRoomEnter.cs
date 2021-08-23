using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRoomEnter : MonoBehaviour
{
    [SerializeField] private LootSpawner lootSpawner;
    [SerializeField] private List<WallOrDoor> wallOrDoors;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("SPAWNING");
        if (other.CompareTag("Player"))
        {
            lootSpawner.SpawnLoot();
            foreach (var wall in wallOrDoors)
            {
                if (wall.isClosed)
                {
                    wall.PlayerEnterRoom();
                }
            }
            gameObject.SetActive(false);
        }
    }
}
