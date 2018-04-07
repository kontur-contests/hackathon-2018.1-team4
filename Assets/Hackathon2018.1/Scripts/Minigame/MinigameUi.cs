using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class MinigameUi : MonoBehaviour {

    public CanvasGroup tutorImage;

    public Image winImage;
    public Image loseImage;

    public Image fadeImage;

    private float tutorTime = 3f;

    public void ShowTutorImage()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.SetUpdate(true);
        sequence.Append(tutorImage.DOFade(1f, 0.5f).SetUpdate(true));
        sequence.Insert(tutorTime, tutorImage.DOFade(0f, 0.5f));
        sequence.Insert(tutorTime, fadeImage.DOFade(0f, 0.5f).OnComplete(()=>MinigameController.instance.StartGame()));
    }

    public void ShowWin()
    {
        winImage.DOFade(1f, 0.2f);
    }

    public void ShowLose()
    {
        loseImage.DOFade(1f, 0.2f);
    }


    public void Fade(bool fadeState)
    {
        fadeImage.DOFade(fadeState ? 1f : 0f, 1f);
    }
}
