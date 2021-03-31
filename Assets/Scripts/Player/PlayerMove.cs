using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerMove : MonoBehaviour
{
    public int MaxSpeed;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    //[SerializeField]
    //private int damage = 1;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        //anim.SetBool("Pl.Run", true);
    }
    // Start is called before the first frame update

    // 캐릭터 움직임
    void Update()
    {
        /*  뛰는모션 구현 */
        rigid.velocity = new Vector2(MaxSpeed, rigid.velocity.y);
        //Vector2 frontVec = new Vector2(rigid.position.x + (MaxSpeed * 0.5f), rigid.position.y);
        //RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("platform"));
        /*  뛰는모션 컫 */

        //Debug.Log(rigid.position.x); //캐릭터 좌표 로그 

        /*  포지션이 0이상이면 실질적으로 뛰지는 않는다. */
        /*if (rigid.position.x > 0)
        {
            BackgroundScroll.speed = 0.1f;
            MaxSpeed = 0;
        }
        else if (rigid.position.x < 0)
        {
            MaxSpeed = 35;
            BackgroundScroll.speed = 0.0f;
            //  포지션 0 컫   
        }*/
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.gameObject.tag);

        if (col.gameObject.tag.Equals("Enemy"))
        {
            //anim.SetBool("Pl.Run", false);
            //OnDamage(col.transform);
            anim.SetBool("Pl.Attack0", true);
            //Player.Hpamount -= 10;
            rigid.AddForce(Vector2.left * 100, ForceMode2D.Impulse);
            //Destroy(col.gameObject);
            //BackgroundScroll.speed = 0;

        }
        //anim.SetBool("Pl.Attack", false);
    }
    void OnDamage(Transform Player)
    {
        rigid.AddForce(Vector2.left * 100, ForceMode2D.Impulse);
    }
}
