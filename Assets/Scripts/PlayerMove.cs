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
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.tag);

        if (col.gameObject.tag.Equals("Enemy"))
        {
            //anim.SetBool("Pl.Run", false);
            OnDamage(col.transform);
            anim.SetBool("Pl.Attack0", true);

        }
        //anim.SetBool("Pl.Attack", false);
    }
    void OnDamage(Transform Player)
    {
        rigid.AddForce(Vector2.left * 100, ForceMode2D.Impulse);
    }
}
