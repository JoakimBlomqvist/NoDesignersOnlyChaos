using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UltimateManager : MonoBehaviour
{

    [SerializeField] private List<UltimateAbility> _ultimateAbilities;
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private Image ultImage;
    
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
                ultImage.sprite = _sprites[0];
                passiveUlt = false;
                break;
            case 1:
                ultimateToUse = _ultimateAbilities[1];
                ultImage.sprite = _sprites[1];
                passiveUlt = false;
                break;
            case 2:
                ultimateToUse = _ultimateAbilities[2];
                ultImage.sprite = _sprites[2];
                passiveUlt = false;
                break;
            case 3:
                ultimateToUse = _ultimateAbilities[3];
                ultImage.sprite = _sprites[3];
                passiveUlt = false;
                break;
            case 4:
                Debug.Log("Bool thing");
                passiveUlt = true;
                boolUltimate = "Revive";
                ultImage.sprite = _sprites[4];
                break;
            case 5:
                ultimateToUse = _ultimateAbilities[4];
                ultImage.sprite = _sprites[5];
                passiveUlt = false;
                break;
        }
    }
    
}
