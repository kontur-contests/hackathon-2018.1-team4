using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScirpt : MonoBehaviour {

    public Text text;

    public int scoreTowin = 150;

	void Start () {
		if(ScoreManager.instance.score >= scoreTowin)
        {
            text.text = "Баланс сил в мире восстановлен и народы коров и людей снова могут жить в мире.  Победа за вами!";
        }
        else
        {
            text.text = "Озоновые дыры стали дырами в вашей репутации. Толпа сжигает вас на костре.";
        }
	}

    private void Update()
    {
        if(Input.anyKey)
        {
            ResetGame();
        }
    }

    public void ResetGame()
    {
        ScoreManager.instance.RestartProgresss();
        Destroy(gameObject.transform.parent.gameObject);
    }
}
