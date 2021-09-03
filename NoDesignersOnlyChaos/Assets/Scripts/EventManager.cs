using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[DefaultExecutionOrder(-1)]
public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public event Action OnDie;
    public event Action OnChangeRoom;
    public event Action<Vector2> OnTriggerRoom;
    public event Action<UltimateAbility> OnSetUltimate;

    public void Die()
    {
        OnDie?.Invoke();
    }

    public void ChangeRoom()
    {
        OnChangeRoom?.Invoke();
    }
    
    public void TriggerRoom(Vector2 vector)
    {
        OnTriggerRoom?.Invoke(vector);
    }

    public void SetUltimate(UltimateAbility ultimate)
    {
        OnSetUltimate?.Invoke(ultimate);
    }



}
