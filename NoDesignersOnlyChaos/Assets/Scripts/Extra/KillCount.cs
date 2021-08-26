using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(1)]
public class KillCount : MonoBehaviour
{
    public int Kills;

    [SerializeField]private int goalToReach;
    public int spawnCount;

    public bool goaledReached = false;
    
    public static KillCount Instance;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    
    private void OnEnable()
    {
        EventManager.instance.OnDie += AddKills;
    }

    private void OnDisable()
    {
        EventManager.instance.OnDie -= AddKills;
    }

    private void AddKills()
    {
        Kills++;

        if (goalToReach == Kills)
        {
            goaledReached = true;
        }
    }

    public void RoomKillCount()
    {
        goalToReach = spawnCount + Kills;
    }

    public void ResetRoomKillCount()
    {
        spawnCount = 0;
    }
}
