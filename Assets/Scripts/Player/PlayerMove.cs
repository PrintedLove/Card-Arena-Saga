using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerMove : MonoBehaviour
{
    private int MaxSpeed = 30;
    Rigidbody2D rigid;
    //SpriteRenderer spriteRenderer;
    public Animator Playeranimator;
    
    
    
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Playeranimator.SetBool("Pl.Run", true);
        
    }
    
    
    public void Player_KnockBack() //플레이어 넉백
    {
        MaxSpeed = 0;
        rigid.AddForce(new Vector2(-3, 0) * 30, ForceMode2D.Impulse);
        Invoke("Maxspeed_Setting", 0.5f);
    }
    

    // 캐릭터 움직임
    void Update()
    {           
        rigid.velocity = new Vector2(MaxSpeed, rigid.velocity.y); // 캐릭터 달리는 속도
    }
    
    public void Maxspeed_Setting()
    {
        MaxSpeed = 30;
    }

}
