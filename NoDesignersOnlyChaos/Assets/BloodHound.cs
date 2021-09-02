using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BloodHound : MonoBehaviour
{
    [SerializeField] private Volume _postVolume;
    [SerializeField] private ColorAdjustments _colorAdjustments;
    [SerializeField] private Color colorShift;
    [Range(0,1f)]
    [SerializeField]private float colorValue;
    [SerializeField] private float movementSpeedBoost;
    [SerializeField] private CharacterMovement playerScript;

    private void Start()
    {
        _postVolume.profile.TryGet(out _colorAdjustments);
        playerScript = PlayerManager.Instance._characterMovement;
    }

    private void ColorShift()
    {
        Debug.Log("COLORCOLORCOLOR");
        colorShift = Color.Lerp(Color.white, Color.red, colorValue);
        
        colorValue += 0.01f;
        
        _colorAdjustments.colorFilter.value = colorShift;

        if (colorValue >= 0.99f)
        {
            CancelInvoke(nameof(ColorShift));
        }

    }
    [ContextMenu("BLOODHOUND")]
    private void BloodHoundVision()
    {
        _colorAdjustments.active = true;
        playerScript.moveSpeed += movementSpeedBoost;
        InvokeRepeating(nameof(ColorShift), 0f, 0.02f);
        StartCoroutine(TurnOff());
    }

    private IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(10f);
        playerScript.moveSpeed -= movementSpeedBoost;
        colorValue = 0;
        _colorAdjustments.active = false;
    }
}
