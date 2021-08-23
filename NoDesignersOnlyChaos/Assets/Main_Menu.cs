using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Main_Menu : MonoBehaviour
{
    public void PlayClickt()
    {
        SceneManager.LoadScene("JockeTest");
    }

    public void SettingsClickt()
    {

    }
    public void QuitClickt()
    {
        Application.Quit();
    }
}
