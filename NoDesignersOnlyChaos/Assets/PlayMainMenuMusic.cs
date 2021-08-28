using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMainMenuMusic : MonoBehaviour
{
    private void OnEnable()
    {
        AudioManager.Instance.OnMainMenuMusic();
    }
}
