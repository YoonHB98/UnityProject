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

    // UI를 잠시 끄는 함수
    public void DisableUI()
    {
        // Canvas가 존재하면
        if (uiCanvas != null)
        {
            // Canvas의 자식 오브젝트들을 가져와서 비활성화
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

    // UI를 다시 활성화하는 함수
    public void EnableUI()
    {
        // Canvas가 존재하면
        if (uiCanvas != null)
        {
            // Canvas의 자식 오브젝트들을 가져와서 활성화
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