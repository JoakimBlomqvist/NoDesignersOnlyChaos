using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZapParticle : MonoBehaviour
{
    public Transform target;
    private Vector3 velocity;
    private bool reachedTarget;
    public int damage;
    
    private void Update()
    {
        //transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, 0.1f);
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
