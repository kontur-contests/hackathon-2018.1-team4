using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class BoxScript : MonoBehaviour {
    private Random rand = new Random();
    protected List<GameObject> pieces = new List<GameObject>();
    private GameObject LeftUpPoint;
    private GameObject RightDownPoint;
    private Text TimeText;
    private Text ShitCount;

    private float time = 30;
    private int CountToWin = 12;
    private int Count = 100;

    private int PoopsCountMax = 50;
    private int PoopsCountMax = 100;
    
    public GameObject[] Shits;

    public void Start()
    {
        LeftUpPoint = GameObject.Find("LeftUpPoint");
        RightDownPoint = GameObject.Find("RightDownPoint");
        TimeText = GameObject.Find("TimeCount").GetComponent<Text>();
        ShitCount = GameObject.Find("ShitCount").GetComponent<Text>();
        GeneratePoops();
        pieces.AddRange(GameObject.FindGameObjectsWithTag("ShitPiece"));

    }

    private void GeneratePoops()
    {
        var leftX = LeftUpPoint.transform.position.x;
        var rightX = RightDownPoint.transform.position.x;
        var upY = LeftUpPoint.transform.position.y;
        var downY = RightDownPoint.transform.position.y;

        var poopsCount = Random.Range(PoopsCountMin, PoopsCountMax);
        for(var i = 0; i < poopsCount; i++)
        {
            var nextCoords = new Vector2(Random.Range(leftX, rightX), Random.Range(downY, upY));
            var rotation = Random.rotation;
            rotation.x = 0;
            rotation.y = 0;

            Instantiate(Shits[Random.Range(1, 4)], nextCoords, rotation);
        }
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

        TimeText.text = time.ToString().Split('.').FirstOrDefault();
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
