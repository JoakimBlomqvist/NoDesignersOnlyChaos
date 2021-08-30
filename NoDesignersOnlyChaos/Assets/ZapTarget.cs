using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ZapTarget : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private int intLayer;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private GameObject prefab;
    [SerializeField] private int zapDamage;
    private List<Collider2D> _collider2Ds;
    private Transform targetTransform;
    private IEnumerator routine;
    [SerializeField]private float cooldown;

    private void OnEnable()
    {
        //routine = ZapRoutine();
        StartCoroutine(ZapRoutine());
    }

    private void Zap()
    {
        _collider2Ds = Physics2D.OverlapCircleAll(transform.position, radius, _layerMask).ToList();
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    IEnumerator ZapRoutine()
    {
        if (cooldown < 0.01)
        {
            Debug.LogWarning("cooldown must be more than 0 on " + this.gameObject.name);
            yield return null;
        }
        while (true)
        {
            Zap();
            float distance = 100f;
            for (int i = 0; i < _collider2Ds.Count; i++)
            {
                float curDistance = Vector3.Distance(transform.position, _collider2Ds[i].transform.position);
                if (curDistance < distance)
                {
                    distance = curDistance;
                    targetTransform = _collider2Ds[i].transform;
                }
            }

            if (targetTransform != null)
            {
                InstantiateParticle();
            }
            Debug.Log(targetTransform);
            Debug.Log("Zap!");
            yield return new WaitForSeconds(cooldown);
        }
        yield return null;
    }

    private void InstantiateParticle()
    {
        GameObject obj = Instantiate(prefab, transform.position, Quaternion.identity);
        ZapParticle particle = obj.GetComponent<ZapParticle>();
        particle.damage = zapDamage;
        particle.target = targetTransform;
        
    }
}
