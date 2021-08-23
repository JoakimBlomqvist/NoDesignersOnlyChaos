using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCount : MonoBehaviour
{
    private int kills;
    [SerializeField]private Animator killAnim;
    public int Kills;
    [SerializeField] private EventManager _eventManager;
    
    private void OnEnable()
    {
        _eventManager.OnDie += AddKills;
    }

    private void AddKills()
    {
        Kills++;
        if (Kills == 5)
        {
            killAnim.Play("New Animation", 0, 1);
        }
    }
}
