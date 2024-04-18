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
    SceneChangeEffect fade;

    public enum PlayLevel
    {
        TestLevel,
        MainMenuLevel,
        CutSceneLevel,
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

    }

    void Start()
    {
        fade = FindObjectOfType<SceneChangeEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeLevel()
    {
        StartCoroutine(LoadLevelAndTogglePause((_playLevel).ToString()));
    }

    public void ChangeLevel(int playLevel)
    {
        PlayLevel _playLevel = (PlayLevel)playLevel;
        StartCoroutine(LoadLevelAndTogglePause((_playLevel).ToString()));
    }

    public void ChangeLevel(string playLevel)
    {
        StartCoroutine(LoadLevelAndTogglePause(playLevel));
    }

    public void ChangeLevelFade()
    {
        StartCoroutine(LoadLevelAndTogglePausewithFade((_playLevel).ToString()));
    }

    public void ChangeLevelFade(int playLevel)
    {
        PlayLevel _playLevel = (PlayLevel)playLevel;
        StartCoroutine(LoadLevelAndTogglePausewithFade((_playLevel).ToString()));
    }

    public void ChangeLevelFade(string playLevel)
    {
        StartCoroutine(LoadLevelAndTogglePausewithFade(playLevel));
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

    private IEnumerator LoadLevelAndTogglePausewithFade(string levelName)
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1.0f);
        // �� �ε�
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelName);

        // ���� �ε�� ������ ���
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // �� �ε� �� �Ͻ����� ���� ����
        TogglePause();
        //fade.FadeOut();
    }

    public void TogglePause()
    {
        //tag�� pauseoverlay�� ������Ʈ���� ã�Ƽ� Ȱ��ȭ/��Ȱ��ȭ
        GameObject[] pauseOverlays = GameObject.FindGameObjectsWithTag("PauseOverlay");
        if (pauseOverlays.Length == 0)
        {
            Debug.LogWarning("No GameObjects with tag 'PauseOverlay' found.");
            return;
        }
        isPaused = !isPaused;
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
