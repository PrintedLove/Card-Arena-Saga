using System.Collections;
using System.Numerics;
using UnityEngine;

public class Enemy_Dish: MonoBehaviour
{
    
    Transform Enemy_Dish_tr;
    SpriteRenderer spriteRenderer;
    //Rigidbody2D rigid;
    //CapsuleCollider2D capsuleCollider;
    //public int KnockSpeed;
    public float speed;
    private bool Dead_flag = true;
    Collider2D DeadCollider;
    Animator Enemy_Dish_animator;
    public int Enemy_Dish_Maxhealth = 100;
    public int Enemy_Dish_Currenthealth;
    public HealthBar Enemy_Dish_Healthbar;
    Rigidbody2D rigid;
    public GameObject Enemy_Damage_Display;

    void Start() // 시작시 필요한것 불러오기.
    {
        Enemy_Dish_tr = GetComponent<Transform>();
        Enemy_Dish_Currenthealth = Enemy_Dish_Maxhealth;  //현재 체력을 나의 maxHealth로 저장
        Enemy_Dish_Healthbar.SetMaxHealth(Enemy_Dish_Maxhealth); //HP를 현재 나의 최대 최력치에 저장한다.
        rigid = GetComponent<Rigidbody2D>();
        DeadCollider = GetComponent<Collider2D>();
        Enemy_Dish_animator = GetComponent<Animator>();
    }

    

    void Update() // 적 이동
    {
        
        Enemy_Dish_tr.Translate(UnityEngine.Vector2.left * speed * Time.deltaTime); //적 왼쪽으로 이동
    }
    public void Enemy_TakeDamage() // Enemy_Dish 체력 하락 함수
    {
        Enemy_Dish_Currenthealth -= PlayerAnim.Player_Warrior_Damaged; //PlayerAnim에 있는 Player_Warrior_Damaged로 현재체력 차감
        Enemy_Dish_Healthbar.SetHealth(Enemy_Dish_Currenthealth); //차감된 체력이 현재체력으로 설정.

        GameObject Enemy_Display = Instantiate(Enemy_Damage_Display, transform.position, UnityEngine.Quaternion.identity);
        Enemy_Display.transform.GetChild(0).GetComponent<TextMesh>().text = PlayerAnim.Player_Warrior_Damaged.ToString();

        if(Enemy_Dish_Currenthealth <= 0)
        {
            if(Dead_flag)
            {
                Dead_flag = false;
                gameObject.layer = 12;
                Enemy_Dish_animator.SetTrigger("Dead");
            }
            
        }
    }

    public void Enemy_KnockBack() // Enemy_Dish 넉백 함수
    {
        rigid.AddForce(new UnityEngine.Vector2(5, 0) * 30, ForceMode2D.Impulse);
    }

    public void Enemy_Dead()
    {

        
        DeadCollider.enabled = false;
        Invoke("DeadActive", 0.6f);
        

    }

    void DeadActive()
    {
        gameObject.SetActive(false);
    }

    private void Dead_flag_True()
    {
        Dead_flag = true;
    }
}
