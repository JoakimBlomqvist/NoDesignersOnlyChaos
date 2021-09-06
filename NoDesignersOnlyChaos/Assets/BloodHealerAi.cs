using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BloodHealerAi : MonoBehaviour
{
    
    [SerializeField] private float radius;
    [SerializeField] private LayerMask _layerMask;
    private List<Collider2D> colliders;
    private Transform targetTransform;
    public int healing;
    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(HealingRouting());
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    private void HealingTargets()
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, radius, _layerMask).ToList();
    }
    
    IEnumerator HealingRouting()
    {
        yield return new WaitForSeconds(3f);

        while (true)
        {
            HealingTargets();
            float distance = 100f;
            for(int i = 0; i < colliders.Count; i++)
            {
                float Enemydistance = Vector3.Distance(transform.position, colliders[i].transform.position);
                if(Enemydistance < distance)
                {
                    distance = Enemydistance;
                    targetTransform = colliders[i].transform;
                }
            }
            if(targetTransform != null && targetTransform.gameObject.activeSelf == true)
            {
                Debug.Log("sUPSUP");
               if(targetTransform.TryGetComponent(out Health health))
                {
                    health.Healing(healing);
                    Debug.Log("healing");
                        
                }


            }
            yield return new WaitForSeconds(3f);
        }
        yield return null;
    }

    /*private void HealingParticle()
    {
        Instantiate()
    }*/
}
