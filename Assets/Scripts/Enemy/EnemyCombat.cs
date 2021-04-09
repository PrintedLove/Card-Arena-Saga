using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Animator animator;

    public Transform Enemy_AttackPoint; //몬스터의 공격 포인트 단지 그점을 참조 
    public float Enemy_attackRange = 15f; //몬스터의 공격 범위
    public LayerMask PlayerLayers; // 어떤 객체가 적이며 여기 레이어에 모든 환경의 물체감지하기 위해 변수 생성 


    void Update()
    {
        Attack();
        
    }

    void Attack()
    {
        Collider2D[] HitPlayers =  Physics2D.OverlapCircleAll(Enemy_AttackPoint.position,Enemy_attackRange,PlayerLayers); // 

        foreach(Collider2D player in HitPlayers)
        {
            if (player.name == "Player")
            {
                Attack_Ani();
                //Debug.Log("We hit " + player.name + HitPlayers.Length);
            }
        }
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(Enemy_AttackPoint.position, Enemy_attackRange);
    }

    void Attack_Ani()
    {
        animator.SetTrigger("Attack");
        Debug.Log("공격");
    }
}
