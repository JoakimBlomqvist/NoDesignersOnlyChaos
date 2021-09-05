using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isFreezed;
    protected void AddSelfToEnemyList()
    {
        //EnemyListHandler.Instance.EnemyList.Add(this.gameObject);
    }

    protected void OnEnable()
    {
        AddSelfToEnemyList();
    }

    private void OnDisable()
    {
        //if(EnemyListHandler.Instance.EnemyList.Contains(this.gameObject))
            //EnemyListHandler.Instance.EnemyList.Remove(this.gameObject);
    }
}
