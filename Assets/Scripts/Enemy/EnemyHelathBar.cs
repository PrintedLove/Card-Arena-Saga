using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHelathBar : MonoBehaviour
{
    [SerializeField]
    private float maxHP;
    private float currentHP;
    private bool isDie = false;
    private Enemy enemy;
    private SpriteRenderer SpriteRenderer;

    void Start()
    {
        currentHP = maxHP;
        enemy = GetComponent<Enemy>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamate(float damage)
    {
        if (isDie == true) return;

        currentHP -= damage;

        if (currentHP <= 0)
        {
            isDie = true;
            enemy.OnDie();
            //EnemyHelathBar.Ondie();
        }
    }

    private 
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(localScale.x);
        //localScale.x = Enemy.Hpamount;
        //transform.localScale = localScale;
    }
}
