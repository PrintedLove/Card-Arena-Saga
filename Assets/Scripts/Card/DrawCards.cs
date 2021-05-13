using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawCards : MonoBehaviour
{
    public GameObject CardArea; // 카드가 존재할 수 있는 패널
    public GameObject Card1; // 카드 객체
    private int CardCount = 0; // 카드의 개수를 세는 변수
    private int CardMax = 14; // 카드는 간격에 맞추어 최대 14장까지 생성될 수 있음

   
    void Start()
    {
        StartCoroutine("AddCard"); // frame이 시작되면 AddCard 메소드를 호출함
    }

    public IEnumerator AddCard()
    {
        while (true)
        {
            if (CardCount == CardMax) // 카드 개수가 최대 개수가 되면 실행을 중지함
            {
                break;
            }
            else
            {
                Debug.Log(CardCount); // 카드 개수 확인용
                GameObject playerCard = Instantiate(Card1, new Vector3(0, 0, 0), Quaternion.identity); // 카드 인스턴스를 생성
                playerCard.transform.SetParent(CardArea.transform, false); // 패널을 인스턴스의 Parent로 지정
                CardCount += 1; // 카드가 추가될 때마다 CardCount가 1 증가함
                yield return new WaitForSeconds(3f); // 해당 메소드를 3초 후에 다시 실행하도록 함. 즉 카드는 3초마다 1개씩 추가됨
            }
        }
    }
}
