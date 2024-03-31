using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //일시정지
    private bool isPaused = false;


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

    public void StartGame()
    {
        StartCoroutine(LoadLevelAndTogglePause("TestLevel"));
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

    public void TogglePause()
    {
        isPaused = !isPaused;
        //tag가 pauseoverlay인 오브젝트들을 찾아서 활성화/비활성화
        GameObject[] pauseOverlays = GameObject.FindGameObjectsWithTag("PauseOverlay");
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
