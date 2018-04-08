using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceCow : MonoBehaviour {

    public float balanceForce = 2f;

    public float startForce = 1f;

    private Rigidbody2D rigidBody2d;
    private Animator animator;

	// Use this for initialization
	void Start () {
        rigidBody2d = GetComponent<Rigidbody2D>();

        rigidBody2d.AddForce(new Vector2(startForce, 0f));

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
	
	// Update is called once per frame
	void Update () {
        float horizontalAxis = Input.GetAxis("Horizontal");
        rigidBody2d.AddForce(new Vector2(horizontalAxis, 0f) * balanceForce * Time.deltaTime);
	}

}
