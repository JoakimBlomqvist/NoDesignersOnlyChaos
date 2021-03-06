using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveAbilityUser : MonoBehaviour
{
    public PassiveAbility _passiveAbility;
    private bool isRepeating;
    public static PassiveAbilityUser Instance;
    private void OnEnable()
    {
        EventManager.instance.OnStartOfGame += StartPassiveAbility;
    }

    private void OnDisable()
    {
        EventManager.instance.OnStartOfGame -= StartPassiveAbility;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    [ContextMenu("StartPassive")]
    private void StartPassiveAbility()
    {
        if (_passiveAbility.isRepeated)
        {
            if (!isRepeating)
                StartCoroutine(RepeatAbilityUse());
        }
        else
        {
            UsePassiveAbility();
        }
    }
    private void UsePassiveAbility()
    {
        _passiveAbility.UseAbility();
    }

    IEnumerator RepeatAbilityUse()
    {
        isRepeating = true;
        while (true)
        {
            UsePassiveAbility();
            yield return new WaitForSeconds(_passiveAbility.cooldown);
        }
        isRepeating = false;
    }
    
}
