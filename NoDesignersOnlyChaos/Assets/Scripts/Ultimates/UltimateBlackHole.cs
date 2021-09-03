using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UltimateBlackHole : UltimateAbility
{
    [SerializeField] private GameObject blackHole;

    public override void UseAbility()
    {
        Instantiate(blackHole, PlayerManager.Instance.playerPosition, Quaternion.identity);
    }
}
