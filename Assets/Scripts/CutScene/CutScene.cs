using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    public TMP_Text text;
    public FadeController fadeController;
    public Sprite[] sprite;
    public Image image;

    bool isClicked = false;

    string[] sentences = new string[]
    {
        "1st",
        "2nd",
        "3rd"
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
                fadeController.fade.FadeOut();
                text.text = sentences[index];
                image.sprite = sprite[index];

            }
            else
            {
                GameManager.instance.ChangeLevel("HomeTownLevel");
            }
            isClicked = false;
        }

    }

}
