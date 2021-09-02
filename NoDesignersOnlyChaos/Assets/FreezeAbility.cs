using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FreezeAbility : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            FreezeAllEnemies();
        }
    }

    public void FreezeAllEnemies()  
    {
        for (int i = 0; i < EnemyListHandler.EnemyList.Count; i++)
        {
            GameObject enemyGameObject = EnemyListHandler.EnemyList[i].gameObject;
            Debug.Log("Freezing " + enemyGameObject.name);
            Enemy enemy = enemyGameObject.GetComponent<Enemy>();
            if (enemy is BomberAi)
            {
                enemyGameObject.GetComponent<BomberAi>().isFreezed = true;
            }
            else
            {
                enemy.enabled = false;
            }
        }
    }
}
