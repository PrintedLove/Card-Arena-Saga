using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerMove : MonoBehaviour
{
    public int MaxSpeed;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
<<<<<<< HEAD
    [SerializeField]
<<<<<<< HEAD
    public Animator Playeranimator;
=======
    Animator anim;
=======
    public Animator anim;
>>>>>>> 90bc7d4 (Enemy)
    public Transform pos;
>>>>>>> parent of bc26929 (Merge pull request #9 from PrintedLove/kwangHo)
    Collider2D col;
    
    public GameObject HitBox;
    
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Playeranimator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        Playeranimator.SetBool("Pl.Run", true);
        
    }
    
    
    

    // 캐릭터 움직임
    void Update()
<<<<<<< HEAD
    {           
=======
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
>>>>>>> parent of bc26929 (Merge pull request #9 from PrintedLove/kwangHo)
        rigid.velocity = new Vector2(MaxSpeed, rigid.velocity.y); // 캐릭터 달리는 속도
    }



    
    
}
