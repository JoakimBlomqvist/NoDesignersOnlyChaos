using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Main_Menu : MonoBehaviour
{
    public GameObject Credits;
    public GameObject Play_Setting_Credits_Quit;
    public GameObject CharacterSelect;
    public void ConfirmClickt()
    {
        SceneManager.LoadScene("JockeTest");
    }

    public void PlayClickt()
    {
        Play_Setting_Credits_Quit.SetActive(false);
        CharacterSelect.SetActive(true);
    }
    public void SettingsClickt()
    {

    }
    public void QuitClickt()
    {
        Application.Quit();
    }

    public void OpenCredits()
    {
        Credits.SetActive(true);
    }
    public void BackToMainMenu()
    {
        Play_Setting_Credits_Quit.SetActive(true);
        CharacterSelect.SetActive(false);
    }
}
