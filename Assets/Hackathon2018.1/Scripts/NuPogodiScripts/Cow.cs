using System;
using System.Collections;
using Hackathon2018._1.NuPogodiScripts;
using UnityEngine;

public class Cow : MonoBehaviour
{
	public StateEnum StateEnum = StateEnum.Mid;
	
	public Horisontal Horisontal = Horisontal.Right;
	public Vector3 CurrentPosition = new Vector3(2, 1);

	private Animator animator;
	
	//todo temp
	private int temp = 0;
	
	void Start ()
	{
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		ChangePosition();
//		if (Input.GetKeyDown(KeyCode.Space))
//		{
//			animator.SetInteger("State", 1);
//			Debug.Log(animator.GetInteger("State"));
//		}
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
			animator.SetInteger("State", 1);
		}

		if (StateEnum == StateEnum.Mid)
		{
			CurrentPosition = new Vector3(CurrentPosition.x, 1);
			transform.localPosition = CurrentPosition;
			animator.SetInteger("State", 2);
		}

		if (StateEnum == StateEnum.Down)
		{
			CurrentPosition = new Vector3(CurrentPosition.x, -2);
			transform.localPosition = CurrentPosition;
			animator.SetInteger("State", 3);
		}
	}
}
