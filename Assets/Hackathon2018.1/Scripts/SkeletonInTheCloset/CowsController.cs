using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowsController : MonoBehaviour {

    public SkeletonCow leftCow;
    public SkeletonCow rightCow;


	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            leftCow.GoInHideState();

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            rightCow.GoInHideState();

    }
}