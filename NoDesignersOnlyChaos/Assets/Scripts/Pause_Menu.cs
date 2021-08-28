using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    [SerializeField] private GameObject DeathScreen;
    [SerializeField] private GameObject pause_Menu;
    [SerializeField] private GameObject settings;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause_Menu.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }

    public void ResumeOnClick()
    {
        pause_Menu.SetActive(false);
        Time.timeScale = 1f;

    }
    public void SettingsOnClick()
    {
        settings.SetActive(true);
    }
    public void RestartOnClick()
    {
        SceneManager.LoadScene("JockeTest");
    }
    public void MainMenuOnClick()
    {
        Time.timeScale = 1f;
        pause_Menu.SetActive(false);
        DeathScreen.SetActive(false);
        settings.SetActive(false);
        SceneManager.LoadScene("Scene_MainMenu");
    }
}
