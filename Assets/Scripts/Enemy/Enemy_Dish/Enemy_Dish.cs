using System.Collections;
using System.Numerics;
using UnityEngine;

public class Enemy_Dish: MonoBehaviour
{
    
    Transform Enemy_Dish_tr;
    //SpriteRenderer spriteRenderer;
    //Rigidbody2D rigid;
    //CapsuleCollider2D capsuleCollider;
    //public int KnockSpeed;
    public float speed;
    //Animator anim;
    public int Enemy_Dish_Maxhealth = 100;
    public int Enemy_Dish_Currenthealth;
    public HealthBar Enemy_Dish_Healthbar;

    void Start() // 시작시 필요한것 불러오기.
    {
        Enemy_Dish_tr = GetComponent<Transform>();
        Enemy_Dish_Currenthealth = Enemy_Dish_Maxhealth;  //현재 체력을 나의 maxHealth로 저장
        Enemy_Dish_Healthbar.SetMaxHealth(Enemy_Dish_Maxhealth); //HP를 현재 나의 최대 최력치에 저장한다.
    }

    

    void Update() // 적 이동
    {
        
        Enemy_Dish_tr.Translate(UnityEngine.Vector2.left * speed * Time.deltaTime); //적 왼쪽으로 이동
    }
}
