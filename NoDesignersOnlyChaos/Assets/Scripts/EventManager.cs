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
    public event Action<Vector2> OnTriggerRoom;

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
    


}
