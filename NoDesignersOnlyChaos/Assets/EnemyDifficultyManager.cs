using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDifficultyManager : MonoBehaviour
{
    public float buffedHP;
    [SerializeField] private int hpPerRoom = 1;
    [SerializeField] private int everyXroom;
    public static EnemyDifficultyManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    
    private void Start()
    {
        buffedHP = 0;
    }

    private void OnEnable()
    {
        EventManager.instance.OnChangeRoom += BuffHp;
    }

    private void OnDisable()
    {
        EventManager.instance.OnChangeRoom -= BuffHp;
    }

    private void BuffHp()
    {
        if (RoomCurrency.Instance.roomCounter % everyXroom == 0)
        {
            Debug.Log("BUFF HP");
            buffedHP += hpPerRoom;
        }
    }
}
