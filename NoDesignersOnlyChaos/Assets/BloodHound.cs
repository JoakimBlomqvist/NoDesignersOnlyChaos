using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BloodHound : MonoBehaviour
{
    [SerializeField] private Volume _postVolume;
    [SerializeField] private ColorAdjustments _colorAdjustments;

    private void Start()
    {
        _postVolume.profile.TryGet(out _colorAdjustments);
    }

    [ContextMenu("BLOODHOUND")]
    private void BloodHoundVision()
    {
        _colorAdjustments.active = true;
        StartCoroutine(TurnOff());
    }

    private IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(10f);
        _colorAdjustments.active = false;
    }
}
