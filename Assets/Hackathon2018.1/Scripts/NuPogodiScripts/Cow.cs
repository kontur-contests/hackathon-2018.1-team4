using System;
using System.Collections;
using System.Linq;
using Hackathon2018._1.NuPogodiScripts;
using UnityEngine;

public class Cow : MonoBehaviour
{
	public StateEnum StateEnum = StateEnum.Mid;
	
	public Horisontal Horisontal = Horisontal.Right;
	public Vector3 CurrentPosition = new Vector3(2, 1);

	private Animator animator;
	private float happyTime = 0;
	private bool isDead = false;
	
	void Start ()
	{
		animator = GetComponent<Animator>();
	}
	
	void Update ()
	{
		ChangePosition();
		if (happyTime > 0)
			happyTime -= Time.deltaTime;
	}

	public void Event(StateEnum state)
	{
		switch (state)
		{
			case StateEnum.Up:
				if (isDead || happyTime > 0)
					break;
				animator.SetInteger("State", 1);
				break;
			case StateEnum.Mid:
				if (isDead || happyTime > 0)
					break;
				animator.SetInteger("State", 2);
				break;
			case StateEnum.Down:
				if (isDead || happyTime > 0)
					break;
				animator.SetInteger("State", 3);
				break;
			case StateEnum.Happy:
				if (isDead || happyTime > 0)
					break;
				animator.SetInteger("State", 4);
				happyTime = 1;
				break;
			case StateEnum.Death:
				if (isDead)
					break;
				animator.SetInteger("State", 5);
				foreach (var food in GameObject.FindGameObjectsWithTag("BadFoodPiece").Union(GameObject.FindGameObjectsWithTag("GoodFoodPiece")))
				{
					Destroy(food.gameObject);
				}
				isDead = true;
				MinigameController.instance.GameOver();
				break;
			default:
				throw new ArgumentOutOfRangeException("state", state, null);
		}
	}
	
	private void ChangePosition()
	{
		var scaleX = transform.localScale.x;
		var scaleZ = transform.localScale.z;
		var scaleY = transform.localScale.y;
		
		var AKey = Input.GetKeyDown(KeyCode.A);
		var LeftKey = Input.GetKeyDown(KeyCode.LeftArrow);
		var DKey = Input.GetKeyDown(KeyCode.D);
		var RightKey = Input.GetKeyDown(KeyCode.RightArrow);
		var WKey = Input.GetKeyDown(KeyCode.W);
		var UpKey = Input.GetKeyDown(KeyCode.UpArrow);
		var SKey = Input.GetKeyDown(KeyCode.S);
		var DownKey = Input.GetKeyDown(KeyCode.DownArrow);

		if ((AKey || LeftKey) && Horisontal == Horisontal.Right)
		{
			Horisontal = Horisontal.Left;
		}

		if ((DKey|| RightKey) && Horisontal == Horisontal.Left)
		{
			Horisontal = Horisontal.Right;
		}

		if ((WKey || UpKey) && StateEnum == StateEnum.Mid)
		{
			StateEnum = StateEnum.Up;
		}

		if ((WKey || UpKey) && StateEnum == StateEnum.Down)
		{
			StateEnum = StateEnum.Mid;
		}

		if ((SKey || DownKey)&& StateEnum == StateEnum.Mid)
		{
			StateEnum = StateEnum.Down;
		}

		if ((SKey || DownKey) && StateEnum == StateEnum.Up)
		{
			StateEnum = StateEnum.Mid;
		}

		if (Horisontal == Horisontal.Left)
		{
			CurrentPosition = new Vector3(-2, CurrentPosition.y);
			transform.localPosition = CurrentPosition;
			transform.localScale = new Vector3(-Mathf.Abs(scaleX), scaleY, scaleZ);
		}

		if (Horisontal == Horisontal.Right)
		{
			CurrentPosition = new Vector3(2, CurrentPosition.y);
			transform.localPosition = CurrentPosition;
			transform.localScale = new Vector3(Mathf.Abs(scaleX), scaleY, scaleZ);
		}

		if (StateEnum == StateEnum.Up)
		{
			CurrentPosition = new Vector3(CurrentPosition.x, 4);
			transform.localPosition = CurrentPosition;
			Event(StateEnum.Up);
		}

		if (StateEnum == StateEnum.Mid)
		{
			CurrentPosition = new Vector3(CurrentPosition.x, 1);
			transform.localPosition = CurrentPosition;
			Event(StateEnum.Mid);
		}

		if (StateEnum == StateEnum.Down)
		{
			CurrentPosition = new Vector3(CurrentPosition.x, -2);
			transform.localPosition = CurrentPosition;
			Event(StateEnum.Down);
		}
	}
}
