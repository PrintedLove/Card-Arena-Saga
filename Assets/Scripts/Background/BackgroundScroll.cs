using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    Material mat;
    float currentXoffset = 0; 
    public static float speed = 0.00f; //x축으로 움직이기위한 스피드 
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;  // SpriteRenderer.material 불러와서 저장한다 
    }

    // Update is called once per frame
    void Update()
    {
        currentXoffset += speed * Time.deltaTime; //x축을 스피드 * 시간만큼 움직여 변수에 저장  
        mat.mainTextureOffset = new Vector2(currentXoffset,0 ); // x축이 움직인만큼을 벡터에 저장하여 돌려줌 
    }
    public void Speed()
    {
        speed = 0.01f;
    }
}
