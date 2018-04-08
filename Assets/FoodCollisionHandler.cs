using Hackathon2018._1.NuPogodiScripts;
using UnityEngine;

public class FoodCollisionHandler : MonoBehaviour
{
	private GameObject cow;
	public Horisontal HandlerDirection;
	public StateEnum State;
	
	private static int score = 0;
	private float timeLeft = 2;

	private bool isGameOver = false;
	
	void Start () 
	{
		cow = GameObject.Find("Cow");
	}

	public void OnTriggerEnter2D(Collider2D collider)
	{
		timeLeft -= Time.deltaTime;
		if ( timeLeft < 0 )
		{
			MinigameController.instance.GameOver();
		}
		var cowState = cow.GetComponent<Cow>().StateEnum;
		var cowDirection = cow.GetComponent<Cow>().Horisontal;
		var foodInfo = collider.GetComponent<FoodInfo>();

		if (!State.Equals(cowState))
			return;

		if (!HandlerDirection.Equals(cowDirection))
			return;

		if (foodInfo.IsPoisoned)
		{
			cow.GetComponent<Cow>().Event(StateEnum.Death);
			isGameOver = true;
		}
		else
		{
			score++;
			cow.GetComponent<Cow>().Event(StateEnum.Happy);
			Destroy(collider.gameObject);

			if (score == 10)
			{
				MinigameController.instance.GameComplete();
			}
		}
	}
}
