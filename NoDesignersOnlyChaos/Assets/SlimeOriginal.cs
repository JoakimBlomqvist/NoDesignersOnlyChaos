using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeOriginal : MonoBehaviour
{
    public int slimesKilled;
    public int slimeCountToReach;

    private void OnEnable()
    {
        slimesKilled = 0;
    }

    public void SlimeCounter()
    {
        slimesKilled++;
        if (slimesKilled == slimeCountToReach)
        {
            EventManager.instance.Die();
        }
    }
}
