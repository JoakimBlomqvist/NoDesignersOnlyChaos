using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ToxicGasDmg : MonoBehaviour
{
    
        [SerializeField] private string tagToDamage;
        [SerializeField] private float damage;
        [SerializeField] private bool destroyOnContact;
        [SerializeField] private float followSpeed;
        private Transform player;

        private void OnEnable()
        {
            player = PlayerManager.Instance.playerTransform;
        }

        private void FixedUpdate()
        {
            var toxicGasPosition = Vector2.Lerp(transform.position, player.position, Time.deltaTime * followSpeed);
            transform.position = new Vector3(toxicGasPosition.x, toxicGasPosition.y, 0f);
        }

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
