using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    
        


    public GameObject pauseMenuUI; 
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Unpause the game
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Pause the game
        isPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f; // Ensure time scale is reset
                             // Load the main menu scene, replace "MainMenu" with your scene name
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
    public void Exitgame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }


}


