using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UltimateManager : MonoBehaviour
{
    //[SerializeField] private List<UltimateAbility> _ultimateAbilities;
    [SerializeField] private UltimateAbility ultimateToUse;

    [ContextMenu("PickedUltimate")]
    private void PickedUltimate()
    {
        EventManager.instance.SetUltimate(ultimateToUse);
    }
}
