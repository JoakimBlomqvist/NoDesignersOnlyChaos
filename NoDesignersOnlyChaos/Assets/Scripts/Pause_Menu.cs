using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    [SerializeField] private GameObject pause_Menu;
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

    }
    public void ControlsOnClick()
    {

    }
    public void MainMenuOnClick()
    {
        SceneManager.LoadScene("Scene_MainMenu");
    }
}
