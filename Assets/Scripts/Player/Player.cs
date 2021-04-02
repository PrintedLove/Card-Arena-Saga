using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100; // 플레이어의 체력
    public int currentHealth; // 플레이어의 현재 체력 

    public HealthBar healthBar;//체력바를 추가하기위한 그것에 대한 참조를 만들어야함  그래서 공중 보건 바를 만듬 
    void Start()
    {
        currentHealth = maxHealth;  //현재 체력을 나의 maxHealth로 저장
        healthBar.SetMaxHealth(maxHealth); //HP를 현재 나의 최대 최력치에 저장한다.
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage) //대미지를 입을 함수 
    {
        currentHealth -= damage; // 현재체력을 damage 매개변수를 받아 그만큼 감소 
        healthBar.SetHealth(currentHealth); // 감소한피를 적용 
    }
}
