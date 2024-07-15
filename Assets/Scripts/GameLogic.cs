using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gamelogic : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI wavetext;
    [SerializeField] int wave = 0;
    public GameObject Plane;

     void Start()
    {

    }
     void Update()
    {
        if (GameObject.FindGameObjectWithTag("Enemy Plane") == null)
        {
            Wave();
        }
        
        
        else
        {
            Debug.Log("Wave Not Called");
        }

    }
    public void Wave()
    {
       
            float x = Random.Range(12.0f, 14.0f);
            float y = Random.Range(1.50f, 3.60f);
            Instantiate(Plane, new Vector2(-x, y), Quaternion.Euler(180f, 0f, 180f));
            wave++;
            wavetext.text = "Wave: " + (wave - 1);
            Debug.Log("Spawn");
        
        

    }
}

