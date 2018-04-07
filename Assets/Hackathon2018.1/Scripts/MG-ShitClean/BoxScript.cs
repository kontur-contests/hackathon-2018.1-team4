using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class BoxScript : MonoBehaviour {

    protected List<GameObject> pieces = new List<GameObject>();
    private GameObject LeftUpPoint;
    private GameObject RightDownPoint;
    private Text TimeText;
    private Text ShitCount;

    private float time = 30;
    private int CountToWin = 5;
    private int Count = 100;

    public void Start()
    {
        LeftUpPoint = GameObject.Find("LeftUpPoint");
        RightDownPoint = GameObject.Find("RightDownPoint");
        TimeText = GameObject.Find("TimeCount").GetComponent<Text>();
        ShitCount = GameObject.Find("ShitCount").GetComponent<Text>();

        pieces.AddRange(GameObject.FindGameObjectsWithTag("ShitPiece"));
    }

    public void Update()
    {
        if (time <= 0)
        {
            MinigameController.instance.GameOver();
        }

        if (Count <= CountToWin)
        {
            MinigameController.instance.GameComplete();
        }

        time -= Time.deltaTime;

        TimeText.text = time.ToString();
        ShitCount.text = (Count - CountToWin).ToString();
    }

    private void OnTriggerStay2D(Collider2D e)
    {
        Count = pieces.Count(piece => 
            piece.transform.position.x >= LeftUpPoint.transform.position.x &&
            piece.transform.position.x <= RightDownPoint.transform.position.x &&
            piece.transform.position.y <= LeftUpPoint.transform.position.y &&
            piece.transform.position.y >= RightDownPoint.transform.position.y
        );
    }
}
