using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour {

    public GameObject StartScreenPrefab;

    public static StartScreen instance;

    void Start () {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            Instantiate(StartScreenPrefab);
        }
	}

}
