using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private GameObject DeathScreen;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Health hpScript;
    
    private Rigidbody2D rb;

    float horizontal;
    float vertical;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hpScript = GetComponent<Health>();
    }
    private void OnDisable()
    {
        AudioManager.Instance.OnGameOverMusic();
        DeathScreen.SetActive(true);
    }
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + new Vector2(horizontal, vertical)*Time.fixedDeltaTime*moveSpeed);
    }



}

