using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class TriggerRoomEnter : MonoBehaviour
{
    [SerializeField] private LootSpawner lootSpawner;
    [SerializeField] private List<WallOrDoor> wallOrDoors;
    private MiniMapGenerator _miniMapGenerator;
    private RoomCoordinates _coordinates;
    private int x, y;
    private bool enemiesSpawned;

    [Header("Lights")] 
    [SerializeField] private List<Light2D> lights;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            KillCount.Instance.goaledReached = false;
            foreach (var light in lights)
            {
                light.enabled = true;
            }
            
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
            EventManager.instance.ChangeRoom();
            StartCoroutine(OpenDoors());
            StartCoroutine(OpenDoorsFalseSafe());
            //gameObject.SetActive(false);
        }
    }

    private IEnumerator OpenDoors()
    {
        yield return new WaitUntil(() => KillCount.Instance.goaledReached);

        StopCoroutine(OpenDoorsFalseSafe());
        foreach (var wall in wallOrDoors)
        {
            if (wall.isClosed)
            {
                wall.OpenDoor();
            }
        }
    }
    
    private IEnumerator OpenDoorsFalseSafe()
    {
        yield return new WaitForSeconds(60f);
        
        StopCoroutine(OpenDoors());
        foreach (var wall in wallOrDoors)
        {
            if (wall.isClosed)
            {
                wall.OpenDoor();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var light in lights)
            {
                light.enabled = false;
            }
        }
    }
}
