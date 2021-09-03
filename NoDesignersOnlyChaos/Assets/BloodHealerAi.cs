using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodHealerAi : MonoBehaviour
{
    
    [SerializeField] private float radius;
    [SerializeField] private LayerMask _layerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
