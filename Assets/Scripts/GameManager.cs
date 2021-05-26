using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject menuSet;
    public GameObject menuSet2;
    public GameObject Main;
    public GameObject ingame;
    public GameObject SB;
    public GameObject SS;


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

        if (Input.GetButtonDown("Enter")) //ESC 메뉴 출력
        {
            if (Main.activeSelf) //ESC로 켜고 끄기 가능하도록
                Main.SetActive(false);
                ingame.SetActive(true);
            // else
            //     Main.SetActive(true);
        }

        if (Input.GetButtonDown("SB")) //ESC 메뉴 출력
        {
            if (SB.activeSelf) //ESC로 켜고 끄기 가능하도록
                ingame.SetActive(false);
                SS.SetActive(true);
        }

    }

    public void GameExit() //게임 종료
    {
        Application.Quit();
    }



}
