using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonCow : MonoBehaviour {

    private Animator animator;

    public ClosetWithSkeletones closetWithSeleton;

    public float hideTime = 0.5f;

    private bool hiden = false;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();

    }
	
    public void GoInHideState()
    {
        if (hiden)
            return;

        StartCoroutine(StartHideCourutine());
    }

    IEnumerator StartHideCourutine()
    {
        hiden = true;
        animator.SetBool("Hiden", true);
        yield return new WaitForSeconds(hideTime);
        animator.SetBool("Hiden", false);
        hiden = false;
    }

    void Update()
    {
        if (closetWithSeleton.skeletonIsShowed && !hiden)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        MinigameController.instance.GameOver();
    }
}
