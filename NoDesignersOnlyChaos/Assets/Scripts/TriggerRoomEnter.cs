using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerRoomEnter : MonoBehaviour
{
    [SerializeField] private LootSpawner lootSpawner;
    [SerializeField] private List<WallOrDoor> wallOrDoors;
    private MiniMapGenerator _miniMapGenerator;
    private RoomCoordinates _coordinates;
    private int x, y;
    private bool enemiesSpawned;
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!enemiesSpawned)
            {
                RoomCurrency.Instance.ResetCurrency();
                RoomCurrency.Instance.roomCounter++;
                lootSpawner.SpawnLoot();
                foreach (var wall in wallOrDoors)
                {
                    if (wall.isClosed)
                    {
                        wall.PlayerEnterRoom();
                    }
                }

                enemiesSpawned = true;
            }
            _miniMapGenerator = GetComponentInParent<MiniMapGenerator>();
            _coordinates = GetComponent<RoomCoordinates>();
            _miniMapGenerator.UpdateMiniMap(_coordinates.coordinates);
            //gameObject.SetActive(false);
        }
    }
}
