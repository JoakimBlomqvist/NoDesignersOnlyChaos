using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BloodHound : UltimateAbility 
{
    [SerializeField] private Volume _postVolume;
    [SerializeField] private ColorAdjustments _colorAdjustments;
    [SerializeField] private Color colorShift;
    [Range(0,1f)]
    [SerializeField]private float colorValue;
    [SerializeField] private float movementSpeedBoost;
    [SerializeField] private CharacterMovement playerScript;
    [SerializeField] private PlayerAimTrollspo _staffScript;
    [SerializeField] private float duration = 10f;
    [SerializeField] private float atsIncrease = 0.75f;
    private float defaultMS;

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
        defaultMS = playerScript.moveSpeed;
    }
    public void ColorShift()
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
    public override void UseAbility()
    {
        _colorAdjustments.active = true;
        playerScript.moveSpeed += movementSpeedBoost;
        _colorAdjustments.postExposure.value = 1f;
        _staffScript.rateOfFire.Value *= atsIncrease;
        InvokeRepeating(nameof(ColorShift), 0f, 0.02f);
        StartCoroutine(TurnOff());
    }

    public IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(duration);
        playerScript.moveSpeed = defaultMS;
        _colorAdjustments.postExposure.value = 0f;
        _staffScript.rateOfFire.Value = _staffScript.spellType.rateOfFire;
        colorValue = 0;
        _colorAdjustments.active = false;
    }
}
