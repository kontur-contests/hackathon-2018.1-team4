using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class BoxScript : MonoBehaviour {

    protected List<GameObject> pieces = new List<GameObject>();
    private GameObject LeftUpPoint;
    private GameObject RightDownPoint;
    private Text CountText;

    public void Start()
    {
        LeftUpPoint = GameObject.Find("LeftUpPoint");
        RightDownPoint = GameObject.Find("RightDownPoint");
        CountText = GameObject.Find("CountText").GetComponent<Text>();
        
        pieces.AddRange(GameObject.FindGameObjectsWithTag("ShitPiece"));
    }

    public void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D e)
    {
        var count = pieces.Count(piece => 
            piece.transform.position.x >= LeftUpPoint.transform.position.x &&
            piece.transform.position.x <= RightDownPoint.transform.position.x &&
            piece.transform.position.y <= LeftUpPoint.transform.position.y &&
            piece.transform.position.y >= RightDownPoint.transform.position.y
        );
        CountText.text = count.ToString();
    }
}
