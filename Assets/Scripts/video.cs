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
    [SerializeField]   VideoPlayer vp;
    private void Start()
    {
        skipbutton.gameObject.SetActive(false);
        vp.loopPointReached += OnVideoEnd;

    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10) 
        {
            skipbutton.gameObject.SetActive(true);
        }
    }
     public void SkipTrailer()
    {
        SceneManager.LoadScene(2);
    }
    private void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(2);
    }
}
