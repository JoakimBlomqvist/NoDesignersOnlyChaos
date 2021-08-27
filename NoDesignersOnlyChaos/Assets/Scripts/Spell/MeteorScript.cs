using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using Random = UnityEngine.Random;

public class MeteorScript : MonoBehaviour
{
    private Vector2 impactPoint;
    private Vector2 newDir;
    [SerializeField] private float meteorSpeed;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private GameObject lightObj;
    private Light2D _light;
    private float value;
    [SerializeField] private AudioClip _meteorClip;
    [SerializeField] private AudioClip _meteorImpactClip;
    private void Start()
    {
        
        PlaySound();
        _light = lightObj.GetComponent<Light2D>();
        impactPoint = UtilsClass.GetMouseWorldPos();
        lightObj.transform.parent = null;
        lightObj.transform.position = impactPoint;
        Vector2 dir = new Vector2(Random.Range(-0.8f, 0.8f), 1);
        transform.position = impactPoint +  dir*10;
        newDir = (impactPoint - new Vector2(transform.position.x,transform.position.y)).normalized;
    }

    private void FixedUpdate()
    {
        _light.pointLightOuterRadius *= 1.15f;
        transform.localScale = transform.localScale * 0.94f;
        transform.position = new Vector3(transform.position.x + newDir.x* Time.fixedDeltaTime * meteorSpeed,
            transform.position.y + newDir.y* Time.fixedDeltaTime *meteorSpeed, transform.position.z);
        if (transform.position.y < impactPoint.y)
        {
            Explode();
            Destroy(lightObj);
            Destroy(gameObject);
        }
    }

    private void PlaySound()
    {
        if (_meteorClip != null)
        {
            SFXManager.Instance._audioSource.PlayOneShot(_meteorClip);
        }
    }
    
    private void Explode()
    {
        if (_meteorImpactClip != null)
        {
            SFXManager.Instance._audioSource.PlayOneShot(_meteorImpactClip);
        }
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
}
