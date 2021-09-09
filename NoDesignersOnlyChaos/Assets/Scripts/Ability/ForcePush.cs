using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ForcePush : PassiveAbility
{
    [SerializeField] private List<Collider2D> pushingEnemies;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private float forceStrength;
    [SerializeField] private ParticleSystem PS;
    private Rigidbody2D enemyrb;
    private Enemy enemyScript;
    private Transform playerTransform;
    public override void UseAbility()
    {
        ForcePushAbility();
    }

    private void ForcePushAbility()
    {
        playerTransform = PlayerManager.Instance.playerTransform;
        Instantiate(PS, playerTransform);
        
        pushingEnemies = Physics2D.OverlapCircleAll(playerTransform.position, range, targetLayer).ToList();

        foreach (var enemy in pushingEnemies)
        {
            enemyScript = enemy.GetComponent<Enemy>();
            enemy.TryGetComponent(out enemyrb);
            if (enemyrb == null) return;
            Vector2 direction = enemyrb.position - new Vector2(playerTransform.position.x, playerTransform.position.y);
            if (enemyScript is GoblinChase || enemyScript is SlimeEnemy)
            {
                StartCoroutine(FreezeDuration(enemyScript));
            }
            
            enemyrb.velocity = Vector2.zero;
            enemyrb.AddForce(direction.normalized * forceStrength);
        }
        
    }

    private IEnumerator FreezeDuration(Enemy enemy)
    {
        enemy.isFreezed = true;
        yield return new WaitForSeconds(0.8f);
        enemy.isFreezed = false;
    }
}
