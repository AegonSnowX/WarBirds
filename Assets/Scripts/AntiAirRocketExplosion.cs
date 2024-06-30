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

          collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.3f;
        Destroy(gameObject);
        //if(collision.gameObject.transform.position.y<=1f)
        
            Destroy(collision.gameObject);  
        
        

    }
}

