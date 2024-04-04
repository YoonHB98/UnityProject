using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //�Ͻ�����
    private bool isPaused = false;
    public int level = 0;
    public PlayLevel _playLevel;

    public enum PlayLevel
    {
        TestLevel,
        MainMenuLevel,
        HomeTownLevel,
        Stage1Level,
        Stage2Level,
        Stage3Level
    }


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeLevel()
    {
        //PlayeLevel�� string���� ��ȯ�Ͽ� LoadLevelAndTogglePause �ڷ�ƾ ����
        StartCoroutine(LoadLevelAndTogglePause((_playLevel).ToString()));
    }

    private IEnumerator LoadLevelAndTogglePause(string levelName)
    {
        // �� �ε�
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelName);

        // ���� �ε�� ������ ���
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // �� �ε� �� �Ͻ����� ���� ����
        TogglePause();
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        //tag�� pauseoverlay�� ������Ʈ���� ã�Ƽ� Ȱ��ȭ/��Ȱ��ȭ
        GameObject[] pauseOverlays = GameObject.FindGameObjectsWithTag("PauseOverlay");
        foreach (GameObject pauseOverlay in pauseOverlays)
        {
            pauseOverlay.SetActive(isPaused);
        }
        //�Ͻ����� ���¿� ���� Time.timeScale ����



        Time.timeScale = isPaused ? 0 : 1;
    }

    public bool GetisPaused()
    {
        return isPaused;
    }
}
