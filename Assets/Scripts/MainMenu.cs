using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MainMenu : MonoBehaviour
{
  

    public void PlayGame()
    {
        SceneManager.LoadScene(1);

    }
    public void Options()
    {

    }
    public void ExitGame()
    {
        Application.Quit();
    }
    // Name of the main level scene

    void Start()
    {

    }
    
}

