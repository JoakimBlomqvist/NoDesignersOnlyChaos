using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UltimateAbility : MonoBehaviour
{
    [Header("UltimateStuff")]
    public int cooldownRooms;
    private int countRooms;
    private bool readyToUse;

    private void OnEnable()
    {
        EventManager.instance.OnChangeRoom += CooldownCount;
        Debug.Log("Subbed");
    }

    private void OnDisable()
    {
        EventManager.instance.OnChangeRoom -= CooldownCount;
    }

    public void UseUltimate()
    {
        if (readyToUse)
        {
            UseAbility();
            countRooms = 0;
            readyToUse = false;
        }
    }
    public virtual void UseAbility()
    {
        Debug.Log("ULTIMATE USE");
    }
    
    private void CooldownCount()
    {
        countRooms++;

        if (countRooms == cooldownRooms)
        {
            readyToUse = true;
            Debug.Log("ULTIMATE READY");
        }
    }
}
