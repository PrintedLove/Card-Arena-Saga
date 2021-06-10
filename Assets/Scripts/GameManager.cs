using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject menuSet;
<<<<<<< Updated upstream
=======
    public GameObject menuSet2;
    public GameObject Main;
    public GameObject ingame;
    public GameObject SB;
    public GameObject SS;
    public GameObject store1;
    public GameObject ex1;
    public GameObject ex2;
    public GameObject ex3;
    public GameObject skip;
>>>>>>> Stashed changes


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel")) //ESC 메뉴 출력
        {
            if (menuSet.activeSelf) //ESC로 켜고 끄기 가능하도록
                menuSet.SetActive(false);
            else
                menuSet.SetActive(true);
        }

    }

    public void GameExit() //게임 종료
    {
        Application.Quit();
    }



}
