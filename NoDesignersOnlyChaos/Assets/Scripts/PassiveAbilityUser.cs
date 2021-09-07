using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveAbilityUser : MonoBehaviour
{
    public PassiveAbility _passiveAbility;
    private bool isRepeating;
    private void OnEnable()
    {
        EventManager.instance.OnStartOfGame += StartPassiveAbility;
    }

    private void OnDisable()
    {
        EventManager.instance.OnStartOfGame -= StartPassiveAbility;
    }

    [ContextMenu("StartPassive")]
    private void StartPassiveAbility()
    {
        Debug.Log("Starting Passive Ability");
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
