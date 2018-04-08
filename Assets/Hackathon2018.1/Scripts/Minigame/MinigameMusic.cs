using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameMusic : MonoBehaviour {

    public AudioClip[] levelMusics;

    public AudioClip getReadyMusic;
    public AudioClip winMusic;
    public AudioClip loseMusic;

    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayLevelMusic()
    {
        audioSource.clip = levelMusics[Random.Range(0, levelMusics.Length)];
        audioSource.loop = false;
        audioSource.Play();
    }

    public void GetReady()
    {
        audioSource.clip = getReadyMusic;
        audioSource.loop = false;
        audioSource.Play();
    }

    public void PlayWinMusic()
    {
        audioSource.clip = winMusic;
        audioSource.loop = false;
        audioSource.Play();
    }

    public void PlayLoseMusic()
    {
        audioSource.clip = loseMusic;
        audioSource.loop = false;
        audioSource.Play();
    }
}
