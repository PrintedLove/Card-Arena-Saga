using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Animator animator;

    public Transform Enemy_AttackPoint;
    public float Enemy_attackRange = 15f;
    public LayerMask PlayerLayers;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] HitPlayers =  Physics2D.OverlapCircleAll(Enemy_AttackPoint.position,Enemy_attackRange,PlayerLayers);

        foreach(Collider2D player in HitPlayers)
        {
            Debug.Log("We hit " + player.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(Enemy_AttackPoint.position, Enemy_attackRange);
    }
}
