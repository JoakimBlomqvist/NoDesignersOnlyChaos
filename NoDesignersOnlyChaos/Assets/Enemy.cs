using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected void AddSelfToEnemyList()
    {
        EnemyListHandler.EnemyList.Add(this.gameObject);
    }

    protected void OnEnable()
    {
        AddSelfToEnemyList();
    }

    private void OnDisable()
    {
        if(EnemyListHandler.EnemyList.Contains(this.gameObject))
            EnemyListHandler.EnemyList.Remove(this.gameObject);
    }
}
