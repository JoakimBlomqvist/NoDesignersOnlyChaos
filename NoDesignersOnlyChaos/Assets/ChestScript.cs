using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChestScript : MonoBehaviour
{
    [SerializeField]private GameObject chest;
    [SerializeField] private Transform Chest;
    [SerializeField] private GameObject[] chestLoot;
    Health healthScript;
    public bool EldklotContact = false;
    
    private void Start()
    {
        Chest = GetComponent<Transform>();
    }

    private void OnDeath()
    {
        DropItem();
    }

    private void DropItem()
    {
        gameObject.SetActive(false);
        Instantiate(chestLoot[Random.Range(0, chestLoot.Length)], gameObject.transform.position, Quaternion.identity);
    }

}
