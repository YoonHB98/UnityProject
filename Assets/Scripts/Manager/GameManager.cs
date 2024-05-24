using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("# Game Object #")]
    public Player player;
    public Poolmanager pool;
    SceneChangeEffect fade;
    public GameObject pauseOverlay;
    [Header("# Game Control #")]
    public float gameTime;
    public float maxGameTime;
    //일시정지
    private bool isPaused = false;
    public int level = 0;
    public PlayLevel _playLevel;

    [Header("# Player Info #")]
    public int PmaxHp = 100;
    public int PcurHp;
    public int Plevel;
    public int PkillCount;
    public int exp;
    public int[] nextExp = { 3, 5, 10, 100, 150, 210, 280, 360, 450, 550, 660, 780, 910, 1050, 1200, 1360, 1530, 1710, 1900, 2100, 2310, 2530, 2760, 3000, 3250, 3510, 3780, 4060, 4350, 4650, 4960, 5280, 5610, 5950, 6300, 6660, 7030, 7410, 7800, 8200, 8610, 9030, 9460, 9900, 10350, 10810, 11280, 11760, 12250, 12750, 13260, 13780, 14310, 14850, 15400, 15960, 16530, 17110, 17700, 18300, 18910, 19530, 20160, 20800, 21450, 22110, 22780, 23460, 24150, 24850, 25560, 26280, 27010, 27750, 28500, 29260, 30030, 30810, 31600, 32400, 33210, 34030, 34860, 35700, 36550, 37410, 38280, 39160, 40050, 40950, 41860, 42780, 43710, 44650, 45600, 46560, 47530, 48510, 49500, 50500, 51510, 52530, 53560, 54600, 55650, 56710, 57780, 58860, 59950, 61050, 62160, 63280, 64410, 65550, 66700, 67860, 69030, 70210, 71400, 72600, 73810, 75030, 76260, 77500, 78750, 80010, 81280, 82560, 83850, 85150, 86460, 87780 };

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
        gameTime += Time.deltaTime;
        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
        
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

    public void GetExp()
    {
        exp++;

        if (exp >= nextExp[Plevel])
        {
            Plevel++;
            exp = exp - nextExp[Plevel - 1];
        }
    }
}
