using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZapAbilityParticle : MonoBehaviour
{
    [HideInInspector]
    public Transform target;
    private Vector3 velocity;
    private bool reachedTarget;
    [HideInInspector]
    public float damage;
    

    private void Update()
    {
        if (target.gameObject.activeSelf && target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, 20f * Time.deltaTime);
            if (Vector3.Distance(transform.position, target.position) < 0.1f && !reachedTarget)
            {
                reachedTarget = true;
                GetComponent<ParticleSystem>().Stop();
                if(target.TryGetComponent(out Health hpScript))
                {
                    hpScript.TakeDamage(damage);
                }
                Destroy(gameObject);
            
            }
        }
        else if(target.gameObject.activeSelf == false)
        {
            Destroy(gameObject);
        }
    }
}
