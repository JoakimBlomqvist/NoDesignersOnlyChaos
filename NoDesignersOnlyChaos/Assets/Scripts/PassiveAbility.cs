using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveAbility : MonoBehaviour
{
    public float cooldown;
    [SerializeField] protected float range;
    public bool isRepeated;
    public virtual void UseAbility()
    {
        
    }
}
