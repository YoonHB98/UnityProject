using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    public TMP_Text text;

    bool isClicked = false;

    string[] sentences = new string[]
    {
        "첫번째 컷씬이에요. 좌클릭시 넘어가요.",
        "2nd",
        "마지막 컷씬이에요. 클릭시 레벨이 넘어가요"
    };
    // 대사의 인덱스
    int index = 0;
    void Awake()
    {

    }
    void Start()
    {
        if (text != null)
        {
            text.text = sentences[index];
        }else
        {
            Debug.LogError("TMP_Text 컴포넌트가 없습니다.");
        }

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isClicked = true;
        }
        if (isClicked)
        {
            index++;
            if (index < sentences.Length)
            {
                text.text = sentences[index];
            }
            else
            {
                GameManager.instance.ChangeLevel("HomeTownLevel");
            }
            isClicked = false;
        }

    }

}
