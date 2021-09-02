using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyListHandler : MonoBehaviour
{
    public List<GameObject> EnemyList = new List<GameObject>();
    public static EnemyListHandler Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
