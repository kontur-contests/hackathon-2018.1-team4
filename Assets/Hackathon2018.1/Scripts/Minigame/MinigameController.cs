using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameController : MonoBehaviour {

    public static MinigameController instance;

    private const string globeSceneName = "Main";

	void Awake ()
    {
        instance = this;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(globeSceneName);
        Debug.Log("Game Over");
    }

    public void GameComplete()
    {
        SceneManager.LoadScene(globeSceneName);
        Debug.Log("Game Complete");
    }

}
