using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Dish_Combat : MonoBehaviour
{
    private Animator Enemy_Dish_animator; // 애니메이션을 실행하기 위한 변수 
    public Rigidbody2D Enemy_Dish_rigid; //넉백을 시키기 위해 필요한 변수
    public LayerMask PlayerLayers; // 어떤 객체가 적이며 여기 레이어에 모든 환경의 물체감지하기 위해 변수 생성 
    public Transform Enemy_Dish_AttackPoint; //몬스터의 공격 포인트 단지 그점을 참조 

    public float Enemy_Dish_attackRange = 15f; //몬스터의 공격 범위
    private bool Enemy_Dish_flag = true; // Update에서 무한 실행을 하지 않기위해 bool선언 
    public static int Enemy_Dish_Damage = 5; //몬스터의 대미지 변수 

    private void Start() //초기 설정 
    {
        Enemy_Dish_rigid = GetComponent<Rigidbody2D>(); //rigid변수에 Rigidbody2D를 저장 
        Enemy_Dish_animator = GetComponent<Animator>(); //animator변수에 애니메이터 저장
    }

    void Update() 
    {
        Enemy_Dish_Attack_Ani();
    }

    void Enemy_Dish_Attack_Ani() //공격 함수 
    {
        Collider2D[] HitPlayers =  Physics2D.OverlapCircleAll(Enemy_Dish_AttackPoint.position,Enemy_Dish_attackRange,PlayerLayers); // Enemy Attack_Point쪽에 닿는 모든것들을 수집 

        foreach (Collider2D player in HitPlayers) // 모든 배열을 foreach로 돌림 
        {
            if (player.name == "Player_Warrior") // 배열중 이름이 Player가 있으면 아래 실행 
            {
                if (Enemy_Dish_flag) 
                { 
                    Enemy_Dish_flag = false; //bool을 이용하여 공격이 끝나는 시점을 저장
                    Attack_Ani(); // 공격 모션 (player라는 Collider2D 매개변수를 전달 )
                }
            }
        }   
    }
    private void Attack() //Animation에서 쓴 함수 (공격을 할 때 피가 따르게 함 )
    {
        Collider2D[] HitPlayers = Physics2D.OverlapCircleAll(Enemy_Dish_AttackPoint.position, Enemy_Dish_attackRange, PlayerLayers); // Enemy Attack_Point쪽에 닿는 모든것들을 수집 

        foreach (Collider2D player in HitPlayers)
        {
            player.GetComponent<Player>().Player_TakeDamage();
        }
    }
    private void  OnDrawGizmosSelected() //AttackPoint를 눈으로 보기위해 쓴 함수 
    {
        Gizmos.DrawWireSphere(Enemy_Dish_AttackPoint.position, Enemy_Dish_attackRange);
    }

    private void Attack_Ani() //공격 애니메이션 함수
    {
        Enemy_Dish_animator.SetTrigger("Attack");
    }
    private void Player_KnockBack() // 튕겨나가는 함수
    {
        Collider2D[] HitPlayers = Physics2D.OverlapCircleAll(Enemy_Dish_AttackPoint.position, Enemy_Dish_attackRange, PlayerLayers); // Enemy Attack_Point쪽에 닿는 모든것들을 수집 

        foreach (Collider2D player in HitPlayers)
        {
            player.GetComponent<PlayerMove>().Player_KnockBack();
        }
    }

    private void Enemy_Dish_Flag_True() // flag 변수 true로 변경 
    {
        Enemy_Dish_flag = true;
    }
}
