using System;
using System.Collections;
using Hackathon2018._1.NuPogodiScripts;
using UnityEngine;

public class Cow : MonoBehaviour
{
	public Height Height = Height.Mid;
	public Horisontal Horisontal = Horisontal.Right;
	public Vector3 currentPosition = new Vector3(2, 1);
	private Eat currentEat;
	public GameObject EatKaktus;
	public GameObject EatBall;
	public GameObject EatBoot;
	public GameObject EatPokemon;
	public GameObject EatCarrot;
	public GameObject EatCabbage;
	public GameObject EatFlower;
	public GameObject EatOats;
	public GameObject EatPumpkin;
	public GameObject EatCannabis;

	void Start ()
	{
		StartCoroutine(Food());
	}
	
	// Update is called once per frame
	void Update ()
	{
		ChangePosition();
		
	}

	IEnumerator Food()
	{
		while (true)
		{
			yield return new WaitForSeconds(3);
			currentEat = EatGenerator.GetRandomEat();
			var food = currentEat.IsPoison ? GetNotEdibleFood() : GetEdibleFood();
			Instantiate(food, currentEat.Position, Quaternion.identity);
			Debug.Log("Упало яйцо");
		}
		
	}

	private GameObject GetNotEdibleFood()
	{
		var random = new System.Random();
		var foods = new[] {EatKaktus, EatBall, EatBoot, EatPokemon};
		return foods[random.Next(0, 4)];
	}

	private GameObject GetEdibleFood()
	{
		var random = new System.Random();
		var foods = new[] {EatCarrot, EatCabbage, EatFlower, EatOats, EatPumpkin, EatCannabis};
		return foods[random.Next(0, 6)];
	}

	
	private void ChangePosition()
	{
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

		if ((WKey || UpKey) && Height == Height.Mid)
		{
			Height = Height.Up;
		}

		if ((WKey || UpKey) && Height == Height.Down)
		{
			Height = Height.Mid;
		}

		if ((SKey || DownKey)&& Height == Height.Mid)
		{
			Height = Height.Down;
		}

		if ((SKey || DownKey) && Height == Height.Up)
		{
			Height = Height.Mid;
		}

		if (Horisontal == Horisontal.Left)
		{
			currentPosition = new Vector3(-2, currentPosition.y);
			transform.localPosition = currentPosition;
		}

		if (Horisontal == Horisontal.Right)
		{
			currentPosition = new Vector3(2, currentPosition.y);
			transform.localPosition = currentPosition;
		}

		if (Height == Height.Up)
		{
			currentPosition = new Vector3(currentPosition.x, 4);
			transform.localPosition = currentPosition;
		}

		if (Height == Height.Mid)
		{
			currentPosition = new Vector3(currentPosition.x, 1);
			transform.localPosition = currentPosition;
		}

		if (Height == Height.Down)
		{
			currentPosition = new Vector3(currentPosition.x, -2);
			transform.localPosition = currentPosition;
		}
	}
}
