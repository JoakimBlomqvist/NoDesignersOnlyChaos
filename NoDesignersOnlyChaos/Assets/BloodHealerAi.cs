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
    [SerializeField] private GameObject healingParticle_Blood;
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
        yield return new WaitForSeconds(2f);

        while (true)
        {
            HealingTargets();
            
                    targetTransform = colliders[Random.Range(0, colliders.Count)].transform;
              
            if(targetTransform != null && targetTransform.gameObject.activeSelf == true)
            {
                Debug.Log("sUPSUP");
               if(targetTransform.TryGetComponent(out Health health))
                {
                    health.Healing(healing);
                    Instantiate(healingParticle_Blood, targetTransform.position, Quaternion.identity);
                    Debug.Log("healing");
                        
                }


            }
            yield return new WaitForSeconds(2f);
        }
        yield return null;
    }

}
