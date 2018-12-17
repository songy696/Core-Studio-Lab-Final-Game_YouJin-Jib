using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public bool GameIsPaused = false;
    public GameObject pauseMenu;
    public string mainMenuScene;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                GameIsPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void Resume()
    {
        GameIsPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("start scene");

    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("01");

    }
}