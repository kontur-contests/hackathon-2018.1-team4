using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ActivityController : MonoBehaviour {

    public Transform activityWarp;
    public float warpRotationSpeed;
    public Transform activityIcon;

    private bool active = false;

    private MinigameData minigameData;

	void Start ()
    {
        activityIcon.GetComponent<SpriteRenderer>().DOFade(0f, 0.01f);
    }
	
	void Update ()
    {
        activityWarp.Rotate(new Vector3(warpRotationSpeed * Time.deltaTime, 0f, 0f), Space.Self);
        transform.LookAt(transform.parent);
        activityIcon.LookAt(Camera.main.transform.position, Vector3.up);
    }

    void OnMouseDown()
    {
        if (minigameData != null && active)
            SceneManager.LoadScene(minigameData.sceneName);
    }

    public void ActivateActivity(MinigameData minigameData)
    {
        this.minigameData = minigameData;

        active = true;
        activityWarp.gameObject.SetActive(true);
        activityIcon.GetComponent<SpriteRenderer>().DOFade(1f, 0.5f);
        activityWarp.parent.DOScale(Vector3.one, 0.3f);
    }

    public void DisableActivity()
    {
        minigameData = null;

        active = false;
        activityWarp.parent.DOScale(Vector3.zero, 0.3f).OnComplete(()=> activityWarp.gameObject.SetActive(true));
        activityIcon.GetComponent<SpriteRenderer>().DOFade(0f, 0.5f);
    }
}
