using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCurrency : MonoBehaviour
{
    public static RoomCurrency Instance;
    private int maxCurrency;
    [SerializeField]public int Currency = 10;
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

    private void Start()
    {
        maxCurrency = Currency;
    }
    public void ResetCurrency()
    {
        maxCurrency = maxCurrency + 1;
        Currency = maxCurrency;
    }
    
    
}
