using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ArtillaryMechanism : MonoBehaviour
{
    [SerializeField] float bulletspeed=3f;
    [SerializeField] GameObject aar;
    [SerializeField] GameObject firingpoint;
    
    float nextFireTime = 0;
    float fireRate = 2f;
    [SerializeField] GameObject Head;
    void Start()
    {

    }
    void Update()
    {
     
            if (Time.time > nextFireTime)
            {
                artillaryAttack();
                nextFireTime = Time.time + fireRate;
              
            }

    }
    public void artillaryAttack()
    {
        float angle = Random.Range(10, 70);
      
        GameObject antiairRocket = Instantiate(aar, firingpoint.transform.position, Quaternion.Euler(0f,0f,angle-37));
        Head.transform.rotation=Quaternion.Euler(0, 0, angle-37);
       
        float angleInRadians= Mathf.Deg2Rad * angle;
        float x = Mathf.Cos(angleInRadians);
        float y = Mathf.Sin(angleInRadians);
        Vector2 direction = new Vector2(x, y);
        Rigidbody2D rb = antiairRocket.GetComponent<Rigidbody2D>();
        rb.velocity = direction*bulletspeed;
        Debug.Log("Firing angle " + direction+" "+ angle + " "+ angleInRadians);

    }
}
