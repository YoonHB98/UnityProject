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
        "ù��° �ƾ��̿���. ��Ŭ���� �Ѿ��.",
        "2nd",
        "������ �ƾ��̿���. Ŭ���� ������ �Ѿ��"
    };
    // ����� �ε���
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
            Debug.LogError("TMP_Text ������Ʈ�� �����ϴ�.");
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
