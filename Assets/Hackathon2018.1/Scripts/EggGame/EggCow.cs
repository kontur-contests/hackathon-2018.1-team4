using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCow : MonoBehaviour {

    private Animator animator;

    public int clickToWin = 200;

    private int clikedTimes;

    private float lastClikTimeStamp;

    private float timeBetweenClicks
    {
        get
        {
            return Time.time - lastClikTimeStamp;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            lastClikTimeStamp = Time.time;
            clikedTimes++;
        }

        if(clikedTimes >= clickToWin)
        {
            MinigameController.instance.GameComplete();
        }

        animator.SetFloat("Progress", (float)clikedTimes /(float)clickToWin);

        animator.SetFloat("Speed", timeBetweenClicks < 0.1f ? 2f : 1f);
	}
}
