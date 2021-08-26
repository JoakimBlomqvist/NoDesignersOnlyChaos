using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class ChestScript : MonoBehaviour
{
    [SerializeField]private GameObject chest;
    [SerializeField] private Transform Chest;
    [SerializeField] private GameObject[] chestLoot;
    Health healthScript;

    private void Start()
    {
        Chest = GetComponent<Transform>();
    }

    public void OnDeath()
    {
        DropItem();
    }

    private void DropItem()
    {
        Instantiate(chestLoot[Random.Range(0, chestLoot.Length)], gameObject.transform.position, Quaternion.identity);
    }

}
