using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeOriginal : MonoBehaviour
{
    public int slimesKilled;
    public int slimeCountToReach;
    [SerializeField] private GameObject firstSlime;

    private void OnEnable()
    {
        slimesKilled = 0;
        firstSlime.SetActive(true);
        firstSlime.transform.position = transform.position;
    }

    public void SlimeCounter()
    {
        slimesKilled++;
        if (slimesKilled == slimeCountToReach)
        {
            EventManager.instance.Die();
            gameObject.SetActive(false);
        }
    }
}
