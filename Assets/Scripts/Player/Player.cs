using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Player_Maxhealth = 100; // 플레이어의 체력
    public static int Player_Currenthealth; // 플레이어의 현재 체력 

    public HealthBar Player_HealthBar;//체력바를 추가하기위한 그것에 대한 참조를 만들어야함  그래서 공중 보건 바를 만듬 

    
    void Start()
    {
        Player_Currenthealth = Player_Maxhealth;  //현재 체력을 나의 maxHealth로 저장
        Player_HealthBar.SetMaxHealth(Player_Maxhealth); //HP를 현재 나의 최대 최력치에 저장한다.
    }

    // Update is called once per frame
    /*void Update()
    {
        Player_Currenthealth = Player_Maxhealth;
        Player_HealthBar.SetHealth(Player_Currenthealth);
    }*/


    public void TakeDamage() //대미지를 입을 함수 
    {
        Player_Currenthealth -= EnemyCombat.Enemy_Damage; // 현재체력을 damage 매개변수를 받아 그만큼 감소 
        Player_HealthBar.SetHealth(Player_Currenthealth); // 감소한피를 적용 

        if(Player_Currenthealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died");
    }
}
