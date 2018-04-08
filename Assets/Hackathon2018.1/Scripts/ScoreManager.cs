using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;

    public GameObject endGamePrefab;

    public float GameTime = 300f;
    public int score;

    private float startGameTimestamp;

    private GameObject endGameObject;

    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        startGameTimestamp = Time.time;
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void RestartProgresss()
    {
        startGameTimestamp = Time.time;
        score = 0;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Time.time - startGameTimestamp >= GameTime && endGameObject == null)
        {
            //TODO: shpw score

            endGameObject = Instantiate(endGamePrefab);
        }
    }


}
