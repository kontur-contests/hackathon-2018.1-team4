using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameMusic : MonoBehaviour {

    public AudioClip winMusic;
    public AudioClip loseMusic;

    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
