using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RifleController : MonoBehaviour {

    public static RifleController instance;

    public Animator animator;

    private enum Side { Left, Right }

    Side _side = Side.Right;
    Side side
    {
        get
        {
            return _side;
        }
        set
        {
            if (value == side)
                return;

            transform.DOLocalMoveX(side == Side.Right ? 2.12f : - 2.12f, 1f);


            _side = value;
        }
    }

    // Use this for initialization
    void Awake () {
        instance = this;
    }

    // Update is called once per frame
    public void Update()
    {
        side = Input.mousePosition.x > Screen.width / 2 ? Side.Right : Side.Left;

        //Debug.Log("Click registered");

        //Debug.Log(Input.mousePosition);
        Vector3 pos = Input.mousePosition;
        pos.z = 100f;
        pos = Camera.main.ScreenToWorldPoint(pos);
        Ray ray = new Ray(pos, Vector3.down);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(hit.point);
        }


    }

    public void Shot()
    {
        animator.SetTrigger("Shoot");
    }
}
