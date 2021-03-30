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
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Create());
    }

    IEnumerator Create()
    {
        while (true)
        {
            if (enemycount == enemymax)
                break;
            float r = Random.Range(limitMin.y, limitMax.y);
            Vector2 creatingPoint = new Vector2(limitMin.x, r);

            Instantiate(prefabEnemy, creatingPoint, Quaternion.identity);
            yield return new WaitForSeconds(createspeed);
            enemycount += 1;

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(limitMin, limitMax);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
