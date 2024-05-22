using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    public Poolmanager pool;
    //일시정지
    private bool isPaused = false;
    public int level = 0;
    public PlayLevel _playLevel;
    SceneChangeEffect fade;
    public GameObject pauseOverlay;

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
        _playLevel = (PlayLevel)playLevel;
        StartCoroutine(LoadLevelAndTogglePause((_playLevel).ToString()));
    }

    public void ChangeLevel(string playLevel)
    {
        _playLevel = (PlayLevel)System.Enum.Parse(typeof(PlayLevel), playLevel);
        StartCoroutine(LoadLevelAndTogglePause(playLevel));
    }

    public void ChangeLevelFade()
    {
        StartCoroutine(LoadLevelAndTogglePausewithFade((_playLevel).ToString()));
    }

    public void ChangeLevelFade(int playLevel)
    {
        _playLevel = (PlayLevel)playLevel;
        StartCoroutine(LoadLevelAndTogglePausewithFade((_playLevel).ToString()));
    }

    public void ChangeLevelFade(string playLevel)
    {
        _playLevel = (PlayLevel)System.Enum.Parse(typeof(PlayLevel), playLevel);
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

        if (pauseOverlay == null)
        {
            Debug.LogWarning("No GameObjects with tag 'PauseOverlay' found.");
            return;
        }else if(_playLevel == PlayLevel.MainMenuLevel || _playLevel == PlayLevel.CutSceneLevel)
        {
            return;
        }

        isPaused = !isPaused;
        pauseOverlay.SetActive(isPaused);
        //일시정지 상태에 따라 Time.timeScale 변경



        Time.timeScale = isPaused ? 0 : 1;
    }

    public bool GetisPaused()
    {
        return isPaused;
    }
}
