using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    PlayerMove player;
    Animator Animator;
    Enemy enemy;
    
    void Start()
    {
        player = GetComponent<PlayerMove>();//PlayerMove 불러오기
        enemy = GetComponent<Enemy>();
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.CompareTag("Enemy")) //적과 충돌시 애니메이션 발동
        {
            
            player.Playeranimator.SetTrigger("Pl.Attack0");
            
            
        }
    }
}
