using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider musicSlider;

    private void OnEnable()
    {
        musicSlider.value = AudioManager.Instance._audioSource.volume;
        volumeSlider.value = AudioManager.Instance._audioSource.volume;
    }

    private void Update()
    {
        AudioManager.Instance._audioSource.volume = musicSlider.value;
        SFXManager.Instance._audioSource.volume = volumeSlider.value;
    }

    public void CloseOptions()
    {
        gameObject.SetActive(false);
    }
}
