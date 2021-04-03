using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerMove : MonoBehaviour
{
    public int MaxSpeed;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    [SerializeField]
    Animator anim;
    public Transform pos;
    Collider2D col;
    public UnityEngine.Vector2 boxSize;
    
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        anim.SetBool("Pl.Run", true);
        
    }
    

    // 캐릭터 움직임
    void Update()
    {
        //히트박스 collider추가
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
        
            foreach (Collider2D collider in collider2Ds )// Collider 접촉시 애니메이션 출력.
            {
           

            if (collider.tag == "Enemy")
            {

                anim.SetTrigger("Pl.Attack0");
                
            }
                           
            }
        rigid.velocity = new Vector2(MaxSpeed, rigid.velocity.y); // 캐릭터 달리는 속도
    }


     private void OnDrawGizmos() // 히트박스 색상밑 설정.
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
    
}
