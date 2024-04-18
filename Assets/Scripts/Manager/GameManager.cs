using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //일시정지
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
        // 씬 로드
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelName);

        // 씬이 로드될 때까지 대기
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // 씬 로드 후 일시정지 상태 변경
        TogglePause();
    }

    private IEnumerator LoadLevelAndTogglePausewithFade(string levelName)
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1.0f);
        // 씬 로드
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelName);

        // 씬이 로드될 때까지 대기
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // 씬 로드 후 일시정지 상태 변경
        TogglePause();
        //fade.FadeOut();
    }

    public void TogglePause()
    {
        //tag가 pauseoverlay인 오브젝트들을 찾아서 활성화/비활성화
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
        //일시정지 상태에 따라 Time.timeScale 변경



        Time.timeScale = isPaused ? 0 : 1;
    }

    public bool GetisPaused()
    {
        return isPaused;
    }
}
