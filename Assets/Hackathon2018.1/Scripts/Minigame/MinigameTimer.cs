using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameTimer : MonoBehaviour {

    public float timeToWin = -1f;
    public float timeToLose = -1f;

    private float startTimeStamp;


	void Start () {
        StartMiniGame();

    }

    public void StartMiniGame()
    {
        startTimeStamp = Time.time;
    }

	void Update ()
    {
		if(timeToWin > 0 && Time.time - startTimeStamp >= timeToWin)
        {
            MinigameController.instance.GameComplete();
        }else if (timeToLose > 0 && Time.time - startTimeStamp >= timeToLose)
        {
            MinigameController.instance.GameOver();
        }
    }
}
