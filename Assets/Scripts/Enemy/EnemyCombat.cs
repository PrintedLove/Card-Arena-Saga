using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Animator animator; // 애니메이션을 실행하기 위한 변수 
    public Rigidbody2D rigid; //넉백을 시키기 위해 필요한 변수
    public Transform Enemy_AttackPoint; //몬스터의 공격 포인트 단지 그점을 참조 
    public float Enemy_attackRange = 15f; //몬스터의 공격 범위
    public LayerMask PlayerLayers; // 어떤 객체가 적이며 여기 레이어에 모든 환경의 물체감지하기 위해 변수 생성 
    public int Enemy_attackMotion = 1; //Enemy의 
    private bool flag = true; // Update에서 무한 실행을 하지 않기위해 bool선언 
    

    private void Start() //초기 설정 
    {
        rigid = GetComponent<Rigidbody2D>(); //rigid변수에 Rigidbody2D를 저장 
    }
    void Update() 
    {
        Attack();
        
    }

    void Attack() //공격 함수 
    {
        Collider2D[] HitPlayers =  Physics2D.OverlapCircleAll(Enemy_AttackPoint.position,Enemy_attackRange,PlayerLayers); // Enemy Attack_Point쪽에 닿는 모든것들을 수집 

        foreach (Collider2D player in HitPlayers) // 모든 배열을 foreach로 돌림 
        {
            if (player.name == "Player") // 배열중 이름이 Player가 있으면 아래 실행 
            {
                if (flag) 
                {
                    flag = false; //bool을 이용하여 한번만 실행 하게끔 만든다 
                    Attack_Ani(); // 공격 모션
                    Invoke("KnockBack", 0.7f); //1초 뒤 KnockBack 함수 호출 
                }
                else
                {
                    Invoke("Flag_True", 2f); // 2초 뒤 Flag_False 함수 호출 
                }
                //Debug.Log("We hit " + player.name + HitPlayers.Length);
            }
        }
        
    }

    void OnDrawGizmosSelected() //AttackPoint를 눈으로 보기위해 쓴 함수 
    {
        Gizmos.DrawWireSphere(Enemy_AttackPoint.position, Enemy_attackRange);
    }

    private void Attack_Ani() //공격 애니메이션 함수 
    {
        animator.SetTrigger("Attack");
        Debug.Log("공격");
        
    }
    private void KnockBack() // 튕겨나가는 함수
    {

        rigid.AddForce(new UnityEngine.Vector2(3, 0) * 40, ForceMode2D.Impulse);
    }

    private void Flag_True() // falg 변수 true로 변경 
    {
        flag = true;
    }
}
