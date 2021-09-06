using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UltimateManager : MonoBehaviour
{
    [SerializeField] private List<UltimateAbility> _ultimateAbilities;
    [SerializeField] private UltimateAbility ultimateToUse;

    [ContextMenu("PickedUltimate")]
    private void OnEnable()
    {
        EventManager.instance.OnStartOfGame += SetUltimate;
    }
    private void OnDisable()
    {
        EventManager.instance.OnStartOfGame += SetUltimate;
    }
    
    private void SetUltimate()
    {
        EventManager.instance.SetUltimate(ultimateToUse);
    }

    public void PickUltimate(int ult)
    {
        switch (ult)
        {
            case 0:
                ultimateToUse = _ultimateAbilities[0];
                break;
            case 1:
                ultimateToUse = _ultimateAbilities[1];
                break;
            case 2:
                ultimateToUse = _ultimateAbilities[2];
                break;
            case 3:
                ultimateToUse = _ultimateAbilities[3];
                break;
            case 4:
                Debug.Log("Bool thing");
                break;
            case 5:
                ultimateToUse = _ultimateAbilities[4];
                break;
        }
    }
}
