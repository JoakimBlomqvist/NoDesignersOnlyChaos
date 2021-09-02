using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected void AddSelfToEnemyList()
    {
        EnemyListHandler.Instance.EnemyList.Add(this.gameObject);
        Debug.Log("Added " + this.gameObject + "  to enemyList");
    }

    protected void OnEnable()
    {
        AddSelfToEnemyList();
    }

    private void OnDisable()
    {
        if(EnemyListHandler.Instance.EnemyList.Contains(this.gameObject))
            EnemyListHandler.Instance.EnemyList.Remove(this.gameObject);
    }
}
