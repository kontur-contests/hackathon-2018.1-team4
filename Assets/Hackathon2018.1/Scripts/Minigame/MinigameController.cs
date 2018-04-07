using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameController : MonoBehaviour {

    public static MinigameController instance;

    public event System.Action OnGameOver;
    public event System.Action OnWin;

    public MinigameUi minigameUi;
    public MinigameMusic minigameMusic;

    private bool ended = false; 

    private const string globeSceneName = "Main";

    private float endGameTime = 3f;

    public bool gamesStarted = false;

	void Awake ()
    {
        instance = this;

        if (minigameUi == null)
            minigameUi = FindObjectOfType<MinigameUi>();

        Debug.Assert(minigameUi != null);

        if (minigameMusic == null)
            minigameMusic = FindObjectOfType<MinigameMusic>();

        Debug.Assert(minigameMusic != null);
    }

    private void Start()
    {
        Time.timeScale = 0f;

        minigameUi.ShowTutorImage();
    }

    public void StartGame()
    {
        gamesStarted = true;
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        if (ended)
            return;

        ended = true;

        minigameUi.ShowLose();
        minigameMusic.PlayLoseMusic();

        if (OnGameOver != null)
            OnGameOver();

        Invoke("GoToGlobe", endGameTime);
        Debug.Log("Game Over");
    }

    public void GameComplete()
    {
        if (ended)
            return;

        ended = true;

        minigameUi.ShowWin();
        minigameMusic.PlayWinMusic();
        Invoke("GoToGlobe", endGameTime);

        if (OnWin != null)
            OnWin();

        Debug.Log("Game Complete");
    }

    public void GoToGlobe()
    {
        minigameUi.Fade(true);
        Invoke("LoadGlobeDelayed", 1f);
    }

    public void LoadGlobeDelayed()
    {
        SceneManager.LoadScene(globeSceneName);
    }

}
