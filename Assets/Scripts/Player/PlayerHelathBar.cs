using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHelathBar : MonoBehaviour
{
    Vector3 localScale;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(localScale.x);
        //localScale.x = Player.Hpamount;
        transform.localScale = localScale;
    }
}
