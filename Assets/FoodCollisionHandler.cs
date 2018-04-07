using Hackathon2018._1.NuPogodiScripts;
using UnityEngine;
using UnityEngine.UI;

public class FoodCollisionHandler : MonoBehaviour
{
	private GameObject cow;
	public Horisontal HandlerDirection;
	public StateEnum State;
	public bool MissZone;

	private Animator animator;

	private static int gameScore = 150;
	private Text textScore;
	
	void Start () {
		cow = GameObject.Find("Cow");
		textScore = GameObject.Find("TextScoreNuPogodi").GetComponent<Text>();
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		textScore.text = "Счет: " + gameScore;
		Debug.Log("State: " + cow.GetComponent<Animator>().GetInteger("State"));
	}

	public void OnTriggerEnter2D(Collider2D collider)
	{
		var cowState = cow.GetComponent<Cow>().StateEnum;
		var cowDirection = cow.GetComponent<Cow>().Horisontal;
		var foodInfo = collider.GetComponent<FoodInfo>();

		if (!foodInfo.IsPoisoned && MissZone)
		{
			gameScore -= 500;
		}
		
		if (!State.Equals(cowState))
			return;

		if (!HandlerDirection.Equals(cowDirection))
			return;

		if (foodInfo.IsPoisoned)
		{
			animator.SetInteger("State", 5);
			MinigameController.instance.GameOver();
		}
		else
		{
			animator.SetInteger("State", 4);
			Destroy(collider.gameObject);
			gameScore += 100;
		}
	}
}
