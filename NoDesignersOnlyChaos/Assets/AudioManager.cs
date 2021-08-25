using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip gameOverMusic;
    [SerializeField] private AudioClip mainMenuMusic;
    [SerializeField] private List<AudioClip> earlyLevels;
    public AudioSource _audioSource;
    [SerializeField] private float increasePitchBy = 0.05f;

    private float songLength;
    public static AudioManager Instance;

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

    private void Start()
    {
        OnEarlyLevelsMusic();
    }

    private void Update()
    {
        if (!_audioSource.isPlaying)
        {
            OnEarlyLevelsMusic();
        }
    }

    public void OnGameOverMusic()
    {
        _audioSource.clip = mainMenuMusic;
        _audioSource.Play();
    }

    public void OnMainMenuMusic()
    {
        _audioSource.clip = gameOverMusic;
        _audioSource.Play();
    }

    public void OnEarlyLevelsMusic()
    {
        int rand = Random.Range(0, earlyLevels.Count);

        _audioSource.clip = earlyLevels[rand];
        _audioSource.Play();
    }

    public IEnumerator InreasePitch()
    {
        float i = 0;
        while (i < increasePitchBy)
        {
            i += 0.0005f;
            yield return new WaitForSeconds(0.04f);
            _audioSource.pitch += 0.0005f;
        }
    }
}
