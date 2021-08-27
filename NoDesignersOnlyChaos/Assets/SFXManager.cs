using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource _audioSource;
    public static SFXManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip, float volume)
    {
        _audioSource.clip = clip;
        _audioSource.volume = volume;
        _audioSource.Play();
    }
}
