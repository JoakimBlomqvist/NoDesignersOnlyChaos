using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void Die()
    {
        OnDie?.Invoke();
    }

    public void ChangeRoom()
    {
        OnChangeRoom?.Invoke();
    }


}
