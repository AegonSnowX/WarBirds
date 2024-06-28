using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A10 : MonoBehaviour
{
    [SerializeField] float FlightSpeed = 3f;
    public SpriteRenderer PlaneA10;
    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        EndLife();
    }
    public void Movement()
    {
       
            
            transform.Translate(Vector3.left * Time.deltaTime * FlightSpeed);
       
    }
    public void EndLife()
    {
        if (transform.position.x <= -11)
        {
           Destroy(gameObject); 
        }
    }
}
