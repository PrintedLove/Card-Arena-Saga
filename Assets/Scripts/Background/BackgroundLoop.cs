using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public GameObject[] levels;              //게임오브젝트 배열을 levels로 선언
    private Camera mainCamera;               //Camera를 mainCamera에 선언
    private Vector2 screenBounds;           //벡터를 screenBounds에 선언 
    public float choke;

    private void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();     // mainCamera변수에 Camera의 정보를 get
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z)); 
        //ScreenToWorldPoint 메서드를 사용하여 화면크기가 얼마가 됫던간에 화면안에서 출력하는 방법하기 위하여 사용

        foreach(GameObject obj in levels)    // Array 객체에서만 사용가능한 메서드 배열의 요소들을 반복하여 작업을 수행
        {
            loadChildObjects(obj);
        }
        
    }
    void loadChildObjects(GameObject obj)
    {
        //Debug.Log(obj.name);
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x - choke;
        int childsNeeded = (int)Mathf.Ceil(screenBounds.x * 2 / objectWidth); // int형 변수를 선언하였지만 ScreenBounds는 float형이기때문에 (int)Mathf.Ceil을 활용하여 float을 인트로 변환
        GameObject clone = Instantiate(obj) as GameObject; // 게임을 실행하는 도중에 게임오브젝트를 동적으로 생성할 수 있다.
        
        for(int i = 0; i <= childsNeeded ; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform) ;
            c.transform.position = new Vector3(objectWidth * i+1, obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;
        }
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }

    void repositionChildObjects(GameObject obj) //화면을 계속 이동시켜주는 함수 
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if(children.Length > 1)
        {
            GameObject firshChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x - choke;
            if(transform.position.x + screenBounds.x  > lastChild.transform.position.x + halfObjectWidth)
            {
                firshChild.transform.SetAsLastSibling();
                firshChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
                
            }
            else if(transform.position.x - screenBounds.x < firshChild.transform.position.x - halfObjectWidth)
            {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firshChild.transform.position.x - halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);

            }
        }
    }
    void LateUpdate()
    {
        foreach(GameObject obj in levels)
        {
            repositionChildObjects(obj);
        }
    }
}
