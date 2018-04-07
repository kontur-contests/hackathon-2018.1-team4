using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndusCow : MonoBehaviour {

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

        MinigameController.instance.OnGameOver += () =>
        {
            animator.SetTrigger("Lose");
        };

        MinigameController.instance.OnWin += () =>
        {
            animator.SetTrigger("Win");
        };
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            lastClikTimeStamp = Time.time;
            clikedTimes++;
        }

        if (clikedTimes >= clickToWin)
        {
            MinigameController.instance.GameComplete();
        }

        animator.SetFloat("Speed", timeBetweenClicks < 0.1f ? 2f : 1f);
    }
}
