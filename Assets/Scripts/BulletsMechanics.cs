using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsMechanics : MonoBehaviour
{
    [SerializeField] Rigidbody2D bulletrb;
    float bulletvelocity = 5f;
    
    void Start()
    {
        
    }

  
    void Update()
    {
        FireDirections();
    }
    void FireDirections()
    {
        bulletrb.velocity = new Vector2(transform.position.x * bulletvelocity * Time.deltaTime, transform.position.y);
    }
}
