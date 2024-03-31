using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Canvas uiCanvas;
    public static UIManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // UI�� ��� ���� �Լ�
    public void DisableUI()
    {
        // Canvas�� �����ϸ�
        if (uiCanvas != null)
        {
            // Canvas�� �ڽ� ������Ʈ���� �����ͼ� ��Ȱ��ȭ
            foreach (Transform child in uiCanvas.transform)
            {
                if (child.CompareTag("PauseOverlay"))
                {
                    continue;
                }
                child.gameObject.SetActive(false);
            }
        }
    }

    // UI�� �ٽ� Ȱ��ȭ�ϴ� �Լ�
    public void EnableUI()
    {
        // Canvas�� �����ϸ�
        if (uiCanvas != null)
        {
            // Canvas�� �ڽ� ������Ʈ���� �����ͼ� Ȱ��ȭ
            foreach (Transform child in uiCanvas.transform)
            {
                if (child.CompareTag("PauseOverlay"))
                {
                    continue;
                }
                child.gameObject.SetActive(true);
            }
        }
    }
}