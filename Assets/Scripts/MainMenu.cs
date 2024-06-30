using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);         // using Index number from build settings
    
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
