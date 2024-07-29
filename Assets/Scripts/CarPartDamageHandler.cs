using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarPartDamageHandler : MonoBehaviour
{
    public Image image;
    public const int MAX_HEALTH = 5;
    private int currentHealth;
    private bool thisObjectDestroyed = false;

    private void Start()
    {
        currentHealth = MAX_HEALTH;
        UpdatePartColor();
    }

    public void DecreaseHealth(int health)
    {
        currentHealth -= health;
        currentHealth = Mathf.Clamp(currentHealth, 0, MAX_HEALTH);// to for example make it 0.7
        UpdatePartColor();
    }

    private void UpdatePartColor()
    {
        if (!thisObjectDestroyed)
        {
            float healthRation = (float)currentHealth / MAX_HEALTH;
            int attempt = 0;

            Color newColor = Color.Lerp(Color.red, Color.yellow, healthRation);
            newColor = Color.Lerp(newColor, Color.green, healthRation);

            image.color = newColor;
            attempt++;
            Debug.Log($"{newColor}");

            if (currentHealth <= 0)
            {
                Debug.Log(gameObject.name + "Destroyed");
                HealthManager.Health -= 25;
                Debug.Log(HealthManager.Health);
                thisObjectDestroyed = true;
            }
        }
       
    }
}
