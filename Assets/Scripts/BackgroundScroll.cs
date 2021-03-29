using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    Material mat;
    float currentYoffset = 0;
    public float speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        currentYoffset += speed * Time.deltaTime;
        mat.mainTextureOffset = new Vector2(currentYoffset,0 );
    }
    public void Speed()
    {
        speed = 0.01f;
    }
}
