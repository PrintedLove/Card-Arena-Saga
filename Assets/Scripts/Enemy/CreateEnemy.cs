using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public GameObject prefabEnemy;

    public float createspeed;
    private int enemycount = 0;
    public int enemymax;
    private GameObject Player;
    //GameObject Player =  GameObject.FindWithTag("Player");
    //private List<Enemy> enemyList;
    //public List<Enemy> EnemyList => enemyList; // 각 개체의 고유한 
    // Start is called before the first frame update
    private void Awake()
    {
        //enemyList = new List<Enemy>();
        StartCoroutine(Create()); //생성 좀 중요한 부분 
        //float creating_x = Player.transform.position.x;
        //Debug.Log(creating_x);

    }

    private IEnumerator Create()
    {
        Player = GameObject.FindWithTag("Player");  // Player Tag Find
        while (true)
        {
            float creating_x = Player.transform.position.x; // Player의 좌표 x를 while로 확인1
            //Debug.Log(creating_x);
            if (enemycount == enemymax) 
                break;
            
            //float r = Random.Range(limitMin.y, limitMax.y);
            Vector2 creatingPoint = new Vector2( creating_x + 200 , 0); // creatingPoint에 좌표 저장 

            GameObject cl = Instantiate(prefabEnemy, creatingPoint, Quaternion.identity); // creatingPoing 기준으로 몬스터 소환 
            cl.name = "Marine" + enemycount; // 소환된 몬스터이름은 Marine + 숫자 ※ 향 후 수정 필요 몬스터이름 아마 배열로 하여 저장할듯 
            //Enemy enemy = clone.GetComponent<Enemy>(); // hp를 다르게하면 각 객체마다 저장하는 ? 

            yield return new WaitForSeconds(createspeed);
            enemycount += 1;

        }
    }

    /*public void DestroyEnemy(Enemy enemy)
    {
        enemyList.Remove(enemy);
        Destroy(enemy.gameObject);
    }*/
    
    // Update is called once per frame
}
