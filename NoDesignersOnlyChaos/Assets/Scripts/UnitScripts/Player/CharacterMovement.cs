using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private GameObject DeathScreen;
    public float moveSpeed;
    [SerializeField] private Health hpScript;
    private bool dashing;
    private bool dashOnCd;
    [SerializeField] private float dashStrength;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashCooldown;
    
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
        if (Input.GetMouseButtonDown(1) && !dashOnCd)
        {
            StartCoroutine(Dash());
            StartCoroutine(DashCooldown());
        }
    }

    void FixedUpdate()
    {
        if (!dashing)
        {
            rb.MovePosition(rb.position + new Vector2(horizontal, vertical) * Time.fixedDeltaTime * moveSpeed);
        }
    }

    private IEnumerator Dash()
    {
        dashing = true;
        Vector2 direction = (UtilsClass.GetMouseWorldPos() - new Vector2(transform.position.x, transform.position.y));
        rb.velocity = Vector2.zero;
        rb.velocity = direction.normalized * dashStrength;
        yield return new WaitForSeconds(dashDuration);
        rb.velocity = Vector2.zero;
        dashing = false;
    }

    private IEnumerator DashCooldown()
    {
        dashOnCd = true;
        yield return new WaitForSeconds(dashCooldown);
        dashOnCd = false;
    }


}

