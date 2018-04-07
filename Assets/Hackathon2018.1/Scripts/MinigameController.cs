using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameController : MonoBehaviour {

    public static MinigameController instance;

    private const string globeSceneName = "Main";

	void Awale ()
    {
        instance = this;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(globeSceneName);
    }

    public void GameComplete()
    {
        SceneManager.LoadScene(globeSceneName);
    }

}
