using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpermBoss : MonoBehaviour
{
    private bool coolDown = false;
    [SerializeField]private GameObject spermPrefab;
    [SerializeField]private float secondsBetweenSpawn;
    void Update()
    {
        if (!coolDown)
        {
            StartCoroutine(SpawnSperm());
        }
    }

    private IEnumerator SpawnSperm()
    {
        coolDown = true;
        Instantiate(spermPrefab, transform.position, quaternion.identity);
        yield return new WaitForSeconds(secondsBetweenSpawn);
        coolDown = false;
    }
}
