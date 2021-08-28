using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMainMenuMusic : MonoBehaviour
{
    public GameObject options;
    private void OnEnable()
    {
        AudioManager.Instance.OnMainMenuMusic();
    }

    public void OnOptionsClick()
    {
        options.SetActive(true);
    }
}
