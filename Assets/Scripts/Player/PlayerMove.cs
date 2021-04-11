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
    public Animator Playeranimator;
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
    {           
        rigid.velocity = new Vector2(MaxSpeed, rigid.velocity.y); // 캐릭터 달리는 속도
    }



    
    
}
