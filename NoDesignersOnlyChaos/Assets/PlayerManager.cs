using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerManager : MonoBehaviour
{
    private CharacterMovement _characterMovement;


    public static GameObject playerObj;
    public static Transform playerTransform;
    public static Vector3 playerPosition;


    private void Awake()
    {
        _characterMovement = FindObjectOfType<CharacterMovement>();
        playerObj = _characterMovement.gameObject;
        playerTransform = playerObj.transform;
    }

    void Update()
    {
        playerPosition = playerTransform.position;
    }
}
