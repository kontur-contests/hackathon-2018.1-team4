using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextUI : MonoBehaviour {

	void Update ()
    {
        if (ScoreManager.instance != null)
            GetComponent<Text>().text = ScoreManager.instance.score.ToString("000");
	}
}
