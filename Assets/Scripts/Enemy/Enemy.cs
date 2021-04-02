﻿using System.Collections;
using System.Numerics;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    
    Transform tr;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    CapsuleCollider2D capsuleCollider;
    public int KnockSpeed;
    public float speed;
    Animator anim;
    
    
    

    
    void Start() // 시작시 필요한것 불러오기.
    {
        
        rigid = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    

    void Update() // 적 이동
    {
        
        tr.Translate(UnityEngine.Vector2.left * speed * Time.deltaTime); //적 왼쪽으로 이동
    }
   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //플레이어 만나면 튕겨나는 함수 호출
        if (collision.gameObject.CompareTag("Player"))
        {
            KnockBack(collision.transform.position);
        }
    }

    public void KnockBack(UnityEngine.Vector2 pos) // 튕겨나가는 함수
    {
        
        rigid.AddForce(new UnityEngine.Vector2(30, 1) * 10, ForceMode2D.Impulse);
        
        
        
    }

    void DeActive()
    {
        gameObject.SetActive(false);
    }
}