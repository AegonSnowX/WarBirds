using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AntiAirRocketExplosion : MonoBehaviour
{
    [SerializeField]GameObject explosion1Prefab;
    [SerializeField] BomberLogic bomberLogic;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


            Destroy(gameObject);
            Destroy(collision.gameObject);  
        
        

    }
}

