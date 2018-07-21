using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScirpt : MonoBehaviour
{

    public Text text;

    public int scoreTowin = 150;

    void Start()
    {
        if (ScoreManager.instance.score >= scoreTowin)
        {
            string t1 = Application.systemLanguage == SystemLanguage.Russian ? "Баланс сил в мире восстановлен и народы коров и людей снова могут жить в мире.  Победа за вами!" :
                "The balance of forces in the world is restored and the peoples of cows and people can again live in peace. Victory is yours!";
            text.text = t1;
        }
        else
        {
            string t1 = Application.systemLanguage == SystemLanguage.Russian ? "Озоновые дыры стали дырами в вашей репутации. Толпа сжигает вас на костре." :
                "Ozone holes have become holes in your reputation. The crowd burns you at the stake.";
            text.text = t1;
        }
    }

    private void Update()
    {
        if (Input.anyKey)
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
