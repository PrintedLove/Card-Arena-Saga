using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public GameObject prefabEnemy;
    public Vector2 limitMin;
    public Vector2 limitMax;
    public float createspeed;
    private int enemycount = 0;
    public int enemymax;
    private List<Enemy> enemyList;
    public List<Enemy> EnemyList => enemyList; // 각 개체의 고유한 
    // Start is called before the first frame update
    private void Awake()
    {
        enemyList = new List<Enemy>();
        StartCoroutine(Create()); //생성 좀 중요한 부분 
    }

    private IEnumerator Create()
    {
        while (true)
        {
            if (enemycount == enemymax) 
                break;

            float r = Random.Range(limitMin.y, limitMax.y);
            Vector2 creatingPoint = new Vector2(limitMin.x, r);

            GameObject clone = Instantiate(prefabEnemy, creatingPoint, Quaternion.identity);
            Enemy enemy = clone.GetComponent<Enemy>(); // hp를 다르게하면 각 객체마다 저장하는 ? 

            yield return new WaitForSeconds(createspeed);
            enemycount += 1;

        }
    }

    public void DestroyEnemy(Enemy enemy)
    {
        enemyList.Remove(enemy);
        Destroy(enemy.gameObject);
    }
    
    // Update is called once per frame
}
