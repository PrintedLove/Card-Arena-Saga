using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int MaxSpeed;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        //사용할것 초기화
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Move();



    }

    // 캐릭터 움직임
    void Update()
    {
        
        if (MaxSpeed > 1)
        {
            //캐릭터 자동이동
            rigid.velocity = new Vector2(MaxSpeed, rigid.velocity.y);
            anim.SetBool("Pl.Run", true);
        }
        else
        {   // 캐릭터 정지 아직 미구현
            MaxSpeed = 0;
            anim.SetBool("Pl.Run", false);
        }
    }

    void Move()
    {
        //캐릭터 이동속도

        MaxSpeed = 30;




    }

    void FixedUpdate()
    {



    }
}
