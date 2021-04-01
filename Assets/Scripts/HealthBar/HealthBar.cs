using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider; //슬라이더 변수선언 
    public Gradient gradient; // 피가 없을수록 색상 변경을 해줄 변수 
    public Image fill; //공개 이미지를 만들어 참조

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health; 
        slider.value = health;

        fill.color = gradient.Evaluate(1f); //그라이데션의 현재 피는 1f 즉 1에 있는 색상
    }
    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue); //  HP가 몇이든 0~1로 환산하여 저장
    }
}
