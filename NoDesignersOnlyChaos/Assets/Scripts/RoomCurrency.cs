using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCurrency : MonoBehaviour
{
    public static RoomCurrency Instance;
    private int currency;
    private int maxCurrency;
    public int Currency
    {
        get => currency;
        set => currency = value;
    }

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

    public void AddCurrency()
    {
        Currency++;
        maxCurrency = maxCurrency + Currency;
    }

    public void ResetCurrency()
    {
        Currency = maxCurrency;
    }
    
    
}
