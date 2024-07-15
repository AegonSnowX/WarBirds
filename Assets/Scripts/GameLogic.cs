using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gamelogic : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI wavetext;
    [SerializeField] int wave = 1;
    public GameObject Plane;

     void Start()
    {

    }
     void LateUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Enemy Plane") == null)
        {
            Wave();
        }
        
    }
    public void Wave()
    {
            for (int i = 0; i < wave; i++)
        {
            float loopCap = 0;
            float x = Random.Range(12.0f, 14.0f);
            float y = Random.Range(1.50f, 3.60f);
            Instantiate(Plane, new Vector2(-x, y), Quaternion.Euler(180f, 0f, 180f));
            wavetext.text = "Wave: " + (wave - 1);
            Debug.Log("Spawn");
            loopCap++;

        }
        wave++;


    }
}

