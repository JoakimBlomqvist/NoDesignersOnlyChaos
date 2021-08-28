using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDifficultyManager : MonoBehaviour
{
    public int buffedHP;
    [SerializeField] private int hpPerRoom = 1;
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
        buffedHP += hpPerRoom;
    }
}
