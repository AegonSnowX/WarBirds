using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;


public class video : MonoBehaviour
{
    float timer = 0f;
    [SerializeField] Button skipbutton;
    
    private void Start()
    {
        skipbutton.gameObject.SetActive(false);
       

    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10) 
        {
            skipbutton.gameObject.SetActive(true);
         
        }
        if(timer>98)
        { 
            LoadNextScene();
        }
    }
     public void SkipTrailer()
    {
        SceneManager.LoadScene(2);
    }
    
    private void LoadNextScene()
    {
        SceneManager.LoadScene(2);
    }
}
