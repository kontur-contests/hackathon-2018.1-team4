using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PoopDieCow : MonoBehaviour {

    public GameObject explosionPrefab;

    public Animator animator;

    public RuntimeAnimatorController[] animators;

    public PoopDieBushManager poopManager;

    public float moveMinSpeed = 2f;
    public float moveMaxSpeed = 10f; 

    public Transform maxPos;
    public Transform minPos;

    public Transform bushPos;

    public enum PoopDieCowState { Normal, Fat }
    PoopDieCowState state = PoopDieCowState.Normal;

    private SpriteRenderer spriteRenderer;

    private float moveSpeed;

    private bool eatBush = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        animator.runtimeAnimatorController = animators[Random.Range(0, animators.Length)];

        poopManager.AddBush();

        moveSpeed = Random.Range(moveMinSpeed, moveMaxSpeed);

        transform.localPosition = new Vector3(Random.Range(minPos.localPosition.x, maxPos.localPosition.x), transform.localPosition.y, Random.Range(minPos.localPosition.z, maxPos.localPosition.z));
        bushPos.localPosition = new Vector3(Random.Range(minPos.localPosition.x, maxPos.localPosition.x), bushPos.localPosition.y, Random.Range(minPos.localPosition.z, maxPos.localPosition.z));
    }

    private void Update()
    {
        if (Vector2.Distance(transform.localPosition, bushPos.localPosition) > 0.1f)
        {
            transform.localPosition += (bushPos.localPosition - transform.localPosition).normalized * moveSpeed * Time.deltaTime;

            spriteRenderer.flipX = (bushPos.localPosition - transform.localPosition).normalized.x < 0f;
        }
        else
            EatBush();
    }

    public void EatBush()
    {
        if (eatBush)
            return;

        animator.SetTrigger("Eat");

        eatBush = true;

        bool fat = Random.Range(0, 2) == 1;

        if(fat)
        {
            animator.SetTrigger("Eat");
            state = PoopDieCowState.Fat;

            Sequence fatSequence = DOTween.Sequence();
            fatSequence.Append(transform.DOScale(transform.localScale * 2f, 2f));
            fatSequence.Append(transform.DOScale(transform.localScale * 2f, 2f)).OnComplete(()=>
            {
                MinigameController.instance.GameOver();
                Destroy(gameObject);
            });
        }
        else
        {
            animator.SetTrigger("EatSimple");
            poopManager.RemoveBush();
        }
    }

    private void OnDestroy()
    {
        Instantiate(explosionPrefab).transform.position = transform.position + new Vector3(0f, 2f, 0f);
    }

    public void OnMouseDown()
    {
        RifleController.instance.Shot();

        if(state == PoopDieCowState.Fat)
        {
            //TODO:Show Animation
            poopManager.RemoveBush();
            Destroy(gameObject);
        }
        else
        {
            MinigameController.instance.GameOver();
        }
    }

}
