using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UiFader : MonoBehaviour {

    Image fadeImage;

    public static UiFader instance;

    // Use this for initialization
    void Start () {
        instance = this;

        fadeImage = GetComponent<Image>();

        Fade(false);
    }

    public void Fade(bool fadeState)
    {
        fadeImage.DOFade(fadeState ? 1f : 0f, 1f);
    }
}
