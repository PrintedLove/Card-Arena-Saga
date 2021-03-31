using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private CreateEnemy createEnemy;

    public void Setup(CreateEnemy createEnemy)
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDie()
    {
        createEnemy.DestroyEnemy(this);
    }
}
