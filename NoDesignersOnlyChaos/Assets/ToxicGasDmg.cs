using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicGasDmg : MonoBehaviour
{
    
        [SerializeField] private string tagToDamage;
        [SerializeField] private float damage;
        [SerializeField] private bool destroyOnContact;
        
        private void OnParticleCollision(GameObject other)
        {
            if (other.gameObject.CompareTag(tagToDamage))
            {
                other.gameObject.GetComponent<IDamageable>().TakeDamage(damage);
            Debug.Log("Hi");
                if (destroyOnContact)
                {
                    Destroy(gameObject);
                }
            }
        }
    
}
