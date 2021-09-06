using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UltimateManager : MonoBehaviour
{
    [SerializeField] private List<UltimateAbility> _ultimateAbilities;
    [SerializeField] private UltimateAbility ultimateToUse;
    [SerializeField] private string boolUltimate;
    private bool passiveUlt;

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
        if (!passiveUlt)
        {
            EventManager.instance.SetUltimate(ultimateToUse);
        }
        else
        {
            EventManager.instance.SetPassiveUlt(boolUltimate);
        }
    }

    public void PickUltimate(int ult)
    {
        switch (ult)
        {
            case 0:
                ultimateToUse = _ultimateAbilities[0];
                passiveUlt = false;
                break;
            case 1:
                ultimateToUse = _ultimateAbilities[1];
                passiveUlt = false;
                break;
            case 2:
                ultimateToUse = _ultimateAbilities[2];
                passiveUlt = false;
                break;
            case 3:
                ultimateToUse = _ultimateAbilities[3];
                passiveUlt = false;
                break;
            case 4:
                Debug.Log("Bool thing");
                passiveUlt = true;
                boolUltimate = "Revive";
                break;
            case 5:
                ultimateToUse = _ultimateAbilities[4];
                passiveUlt = false;
                break;
        }
    }
}
