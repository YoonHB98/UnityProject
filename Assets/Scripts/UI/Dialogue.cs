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
            "ù ��° ��ȭ�Դϴ�.",
            "�� ��° ��ȭ�Դϴ�.",
            "�� ��° ��ȭ�Դϴ�."
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

        // ���콺 Ŭ���� �����Ͽ� ���� ��ȭ�� �Ѿ��
        if (Input.GetMouseButtonDown(0))
        {
            NextDialogue();
        }
    }

    IEnumerator ShowDialogue()
    {
        // ���� ��ȭ �ؽ�Ʈ�� �� ���ھ� ǥ��
        foreach (char letter in dialogues[currentIndex].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(0.1f); // ���� ��� �ð��� ���� ������
        }
    }

    void NextDialogue()
    {
        StopAllCoroutines(); // ���� ���� ���� ��ȭ ǥ�� �ڷ�ƾ ����
                             //���� ��ȭ�� ������ �ʾҴٸ� �ؽ�Ʈ�� ��� ǥ��
        if (dialogueText.text != dialogues[currentIndex])
        {
            dialogueText.text = dialogues[currentIndex];
            return;
        }


        if (currentIndex + 1 < dialogues.Length)
        {
            currentIndex++;
            dialogueText.text = ""; // ��ȭ �ؽ�Ʈ �ʱ�ȭ
            StartCoroutine("ShowDialogue");
        }
        else
        {
            Debug.Log("��� ��ȭ�� ����Ǿ����ϴ�.");
            GameManager.instance.TogglePause();
            UIManager.instance.EnableUI();
            Destroy(gameObject);
        }
    }
}
