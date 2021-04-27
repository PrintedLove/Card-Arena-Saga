using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    PlayerMove Player_Warrior;
    public Rigidbody2D rigid; //RigidBody2D 변수 선언,Player_Warrior(PlayerAnim)에 RigidBody 추가
    public LayerMask EnemyLayer; //Enemy 레이어 변수선언,Player_Warrior(PlayerAnim)에 Layer 추가
    public Transform Player_Warrior_FindEnemy; // Transform 위치 변수 선언 ,Player_Warrior(PlayerAnim)에 Transform 추가
    Animator Player_Warrior_Anim; // Animator 변수 선언, 플레이어의 애니메이터를 사용하기위해 추가

    public static int Player_Warrior_Damaged = 3; // Player_Warrior 기본공격력
    private bool Player_Warrior_Limit = true; // 무한공격 제한
    public float Player_Warrior_HitBox = 9f; // 히트박스 크기 지정
    
    void Start()
    {
        Player_Warrior = GetComponent<PlayerMove>();//PlayerMove 불러오기
        Player_Warrior_Anim = GetComponent<Animator>();//Animator 불러오기
        
    }

    
    void Update()
    {
        Player_Warrior_Search(); // Collider2D에서 접근 데이터 동기화.
    }

    void Player_Warrior_Search() // Collider2D를 사용하여 접근 데이터 찾기
    {
        Collider2D[] PvE_Attack = Physics2D.OverlapCircleAll(Player_Warrior_FindEnemy.position, Player_Warrior_HitBox, EnemyLayer); 
        

        foreach (Collider2D Enemy in PvE_Attack)
        {
            if (Enemy.tag == "Enemy_Dish") // Collider2D와 닿는것이 Enemy_Dish 태그와 일치 검사
            {
                if (Player_Warrior_Limit) // 무한공격방지
                {
                    Player_Warrior_Limit = false; // false로 바꿔 공격 일시 정지
                    Player_Warrior_AttackAnim(); // 공격 애니메이션 함수 출력
                }
                
            }
        }
    }
    

    private void Player_Warrior_AttackAnim() // 공격 애니메이션 함수
    {
        Player_Warrior_Anim.SetTrigger("Pl.Attack0"); 
    }

    private void Player_Warrior_Attack() //Player_Warrior가 공격시 Enemy_Dish 체력 하락
    {
        Collider2D[] HitBox = Physics2D.OverlapCircleAll(Player_Warrior_FindEnemy.position, Player_Warrior_HitBox, EnemyLayer);
        foreach (Collider2D Enemy_Attack in HitBox)
        {
            Enemy_Attack.GetComponent<Enemy_Dish>().Enemy_TakeDamage(); // Enemy_Dish.cs에 있는 TakeDamage함수 호출.
        }
    }

    private void Enemy_KnockBack_Call() // Enemy_KnockBack 함수
    {
        Collider2D[] HitBox = Physics2D.OverlapCircleAll(Player_Warrior_FindEnemy.position, Player_Warrior_HitBox, EnemyLayer);

        foreach(Collider2D Enemy_KnockBack in HitBox)
        {
            Enemy_KnockBack.GetComponent<Enemy_Dish>().Enemy_KnockBack(); //Enemy_Dish에 있는 KnockBack함수 호출

        }
    }
    private void Player_Warrior_Limit_True() // Player_Warrior 공격제한 해제
    {
        Player_Warrior_Limit = true;
    }
}
