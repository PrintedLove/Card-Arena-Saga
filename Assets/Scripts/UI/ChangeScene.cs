using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeSceneBtn()
    {
        switch (this.gameObject.name)
        {
            case "MainScene":
                SceneManager.LoadScene("MainScene");
                break;
            case "Stage1":  //Stage1 버튼을 눌렀다면
                SceneManager.LoadScene("STAGE1");   //STAGE1 Scene을 로드합니다.
                break;
            case "Stage2":  
                SceneManager.LoadScene("STAGE2");  
                break;

        }
    }

   
}
