using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerManager : MonoBehaviour
{
    public CharacterMovement _characterMovement;


    public GameObject playerObj;
    public Transform playerTransform;
    public Vector3 playerPosition;

    public static PlayerManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        
        _characterMovement = FindObjectOfType<CharacterMovement>();
        playerObj = _characterMovement.gameObject;
        playerTransform = playerObj.transform;
    }

    void Update()
    {
        playerPosition = playerTransform.position;
    }
}
