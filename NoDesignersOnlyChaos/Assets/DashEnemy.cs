using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEnemy : MonoBehaviour
{
    private List<Collider2D> targets;
    private Collider2D Lockedtarget;
    [SerializeField] private LayerMask targetLayer = 7;
    void Update()
    {
        Lockedtarget = Physics2D.OverlapCircle(transform.position, 8f, targetLayer);
    }
}
