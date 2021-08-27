using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCurrency : MonoBehaviour
{
    public static RoomCurrency Instance;
    private int maxCurrency;
    [SerializeField]public int Currency = 10;
    private int subCurrency = 0;
    public int roomCounter;
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
        subCurrency += 1;
        if (subCurrency >= 3)
        {
            maxCurrency = maxCurrency + 1;
            subCurrency = 0;
        }
        Currency = maxCurrency;
    }   
}
