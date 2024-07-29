using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;

    public const float MAX_HEALTH = 100;
    public static float Health;

    public GameObject gameOver;

    private void Awake()
    {
        Health = MAX_HEALTH;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // I will add this in case we want to change scenes then gameManager won't get destroyed while loading other scenes
        }
        else
        {
            Destroy(gameObject); // if there is an instance there it will destroy
        }
    }
    private void Update()
    {
        if (Health == 0)
        {
            GameOver();
        }
    }

    public void DecreaseHealth(float health)
    {
        Health -= health;
        Debug.Log(Health);
    }

    public void GameOver()
    {
        Destroy(GameObject.Find("Vehicle"));
        gameOver.SetActive(true);
    }
}
