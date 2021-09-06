using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class FireStormUltimate : UltimateAbility
{
    [SerializeField]private int meteorsToSpawn;
    [SerializeField] private float SpawnRate;
    [SerializeField]private Vector2 meteorSpreadRangeX;
    [SerializeField]private Vector2 meteorSpreadRangeY;
    private List<Vector2> impactPoints = new List<Vector2>();
    [SerializeField] private GameObject meteorPrefab;
    private bool isFiring;

    private void Start()
    {
        for (int i = 0; i < meteorsToSpawn; i++)
        {
            impactPoints.Add(new Vector2(Random.Range(meteorSpreadRangeX.x,meteorSpreadRangeX.y),
                Random.Range(meteorSpreadRangeY.x,meteorSpreadRangeY.y)));
        }
    }

    public override void UseAbility()
    {
        if(!isFiring)
            StartCoroutine(SpawnMeteorRoutine());
    }

    IEnumerator SpawnMeteorRoutine()
    {
        isFiring = true;
        for (int i = 0; i < impactPoints.Count; i++)
        {
            Vector2 playerPos = new Vector2(PlayerManager.Instance.playerPosition.x,
                PlayerManager.Instance.playerPosition.y);
            Instantiate(meteorPrefab, playerPos + impactPoints[i], quaternion.identity);
            yield return new WaitForSeconds(SpawnRate);
        }

        isFiring = false;
    }
}
