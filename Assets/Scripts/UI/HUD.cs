using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Exp, Level, Kill, Time, Health}
    public InfoType type;

    TMP_Text myText;
    Slider mySlider;

    private void Awake()
    {
        myText = GetComponent<TMP_Text>();
        mySlider = GetComponent<Slider>();
    }

    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                float curExp = GameManager.instance.exp;
                float maxExp = GameManager.instance.nextExp[GameManager.instance.Plevel];
                mySlider.value = curExp / maxExp;
                break;
            case InfoType.Level:
                myText.text = string.Format("Lv.{0:F0}", GameManager.instance.Plevel); // F0은 소수점 없애기
                break;
            case InfoType.Kill:
                myText.text = string.Format("Kills : {0:F0}", GameManager.instance.PkillCount);
                break;
            case InfoType.Time:
                float reaminTime = GameManager.instance.maxGameTime - GameManager.instance.gameTime;
                int min = Mathf.FloorToInt(reaminTime / 60);
                int sec = Mathf.FloorToInt(reaminTime % 60); //나머지 연산자
                myText.text = string.Format("{0:D2}:{1:D2}", min, sec); // D2는 두자리로 고정
                break;
            case InfoType.Health:
                float curHp = GameManager.instance.PcurHp;
                float maxHp = GameManager.instance.PmaxHp;
                mySlider.value = curHp / maxHp;
                break;
        }
    }
}
