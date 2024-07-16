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
            float x = Random.Range(12.0f, 14.0f);
            float y = Random.Range(1.50f, 3.60f);
            int shuffleside = Random.Range(1, 3);
            if (shuffleside == 2) 
            { 
                Instantiate(Plane, new Vector2(-x, y), Quaternion.Euler(180f, 0f, 180f));
            }
            else
            {
                Instantiate(Plane, new Vector2(x, y), Quaternion.Euler(180f, 0f, 180f));
            }
            wavetext.text = "Wave: " + wave; 
            Debug.Log("Spawn");
        }
        wave++;

}
}

