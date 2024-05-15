using System.Collections;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TMP_Text dialogueText;
    private string[] dialogues;
    private int currentIndex;

    enum DialogueTime
    {
        Tutorial1,
        Tutorial2,
        Tutorial3
    }

    private void Awake()
    {
        dialogueText.text = "";
        dialogues = new string[]
        {
            "첫 번째 대화입니다.",
            "두 번째 대화입니다.",
            "세 번째 대화입니다."
        };
    }

    void Start()
    {
        currentIndex = 0;
        Time.timeScale = 1;
        StartCoroutine(ShowDialogue());
        UIManager.instance.DisableUI();
    }

    void Update()
    {

        // 마우스 클릭을 감지하여 다음 대화로 넘어가기
        if (Input.GetMouseButtonDown(0))
        {
            NextDialogue();
        }
    }

    IEnumerator ShowDialogue()
    {
        // 현재 대화 텍스트를 한 글자씩 표시
        foreach (char letter in dialogues[currentIndex].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(0.1f); // 실제 경과 시간에 따른 딜레이
        }
    }

    void NextDialogue()
    {
        StopAllCoroutines(); // 현재 진행 중인 대화 표시 코루틴 중지
                             //만약 대화가 끝나지 않았다면 텍스트를 모두 표시
        if (dialogueText.text != dialogues[currentIndex])
        {
            dialogueText.text = dialogues[currentIndex];
            return;
        }


        if (currentIndex + 1 < dialogues.Length)
        {
            currentIndex++;
            dialogueText.text = ""; // 대화 텍스트 초기화
            StartCoroutine("ShowDialogue");
        }
        else
        {
            Debug.Log("모든 대화가 종료되었습니다.");
            GameManager.instance.TogglePause();
            UIManager.instance.EnableUI();
            Destroy(gameObject);
        }
    }
}
