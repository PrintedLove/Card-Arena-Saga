using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Transform tr;
    Rigidbody2D rigid;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.Translate(Vector2.left * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            //Enemy.Hpamount -= 1;
            rigid.AddForce(Vector2.left * 100, ForceMode2D.Impulse);
        }
        //anim.SetBool("Pl.Attack", false);
    }
}
