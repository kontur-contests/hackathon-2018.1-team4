using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ClosetWithSkeletones : MonoBehaviour {

    public Sprite[] skeletonSprites;

    public SpriteRenderer spriteRenderer;
    public Transform endPos;

    public float minTime;
    public float maxTime;

    public Animator closetAnimator;

    public bool skeletonIsShowed;

    private Vector3 startPos;

	// Use this for initialization
	void Start ()
    {
        startPos = spriteRenderer.transform.localPosition;

        StartCoroutine(ShowSkeletonCourutine());
    }
	

    public void ShowSkeletone()
    {
        spriteRenderer.color = Color.white;
        spriteRenderer.sprite = skeletonSprites[Random.Range(0, skeletonSprites.Length)];
        spriteRenderer.transform.DOLocalMove(endPos.localPosition, 0.3f);
        skeletonIsShowed = true;
    }

    public void HideSkeletone()
    {
        spriteRenderer.transform.DOLocalMove(startPos, 0.3f).OnComplete(() => spriteRenderer.color = Color.clear);
        skeletonIsShowed = false;
    }

    IEnumerator ShowSkeletonCourutine()
    {
        while(true)
        {

            yield return new WaitForSeconds(Random.Range(minTime, maxTime));

            if (Random.Range(0, 2) == 1)
                closetAnimator.SetTrigger("Open");
            else
                closetAnimator.SetTrigger("Shake");
        }
    }
}
