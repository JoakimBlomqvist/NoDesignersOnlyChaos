using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MoonHound : UltimateAbility
{
    [SerializeField] private Volume _postVolume;
    [SerializeField] private ColorAdjustments _colorAdjustments;
    [SerializeField] private Color colorShift;
    [SerializeField] private PassiveAbilityUser passiveScript;
    [Range(0,1f)]
    [SerializeField]private float colorValue;
    [SerializeField] private float dashCD = 0.5f;
    [SerializeField] private CharacterMovement playerScript;
    [SerializeField] private PlayerAimTrollspo _staffScript;
    [SerializeField] private float duration = 10f;
    [SerializeField] private float defaultPassiveCd;
    [SerializeField] private float passiveCDBuff = 0.5f;

    private void Awake()
    {
        EventManager.instance.OnStartOfGame += StartOfGame;

    }

    private void StartOfGame()
    {
        _postVolume = PostProcessingManager.Instance.postProcessingVolume;
        _postVolume.profile.TryGet(out _colorAdjustments);
        playerScript = PlayerManager.Instance._characterMovement;
        _staffScript = PlayerManager.Instance._playerStaffScript;
        passiveScript = PassiveAbilityUser.Instance;
        defaultPassiveCd = passiveScript._passiveAbility.cooldown;
    }
    public void ColorShift()
    {
        Debug.Log("COLORCOLORCOLOR");
        colorShift = Color.Lerp(Color.white, new Color(0.3f, 0.3f, 1f, 0.75f), colorValue);
        
        colorValue += 0.01f;
        
        _colorAdjustments.colorFilter.value = colorShift;

        if (colorValue >= 0.99f)
        {
            CancelInvoke(nameof(ColorShift));
        }

    }

    [ContextMenu("MoonHound")]
    public override void UseAbility()
    {
        _colorAdjustments.active = true;
        _colorAdjustments.postExposure.value = 3f;
        playerScript.dashCooldown *= dashCD;
        passiveScript._passiveAbility.cooldown *= passiveCDBuff;//-----Passive Cooldown----//
        InvokeRepeating(nameof(ColorShift), 0f, 0.02f);
        StartCoroutine(TurnOff());
    }

    public IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(duration);
        playerScript.dashCooldown /= dashCD;
        passiveScript._passiveAbility.cooldown = defaultPassiveCd;//Passive Cooldown//
        _colorAdjustments.postExposure.value = 0f;
        colorValue = 0;
        _colorAdjustments.active = false;
    }
}
