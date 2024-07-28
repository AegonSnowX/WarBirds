using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A10 : MonoBehaviour
{
    [SerializeField] float FlightSpeed = 3f;
    public SpriteRenderer PlaneA10;
    public Rigidbody2D rb;
    [SerializeField] GameObject Bullets;
    [SerializeField] GameObject FiringPoint;
    private Transform truck;
    float BulletSpread = 3f;
    float BulletSpeed = 8f;
    float bulletsFiredInBurst = 0;
    float bulletsPerBurst = 20;
    float fireRate = 0.05f;
    float nextFireTime = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        truck = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement();
        //EndLife();
        if (PlaneA10.transform.position.x < 9)
        {
            if (bulletsFiredInBurst < bulletsPerBurst)
            {
                   
                if (Time.time > nextFireTime) 
                { 
                    AttackMechanism();
                    nextFireTime = Time.time+fireRate;
                  bulletsFiredInBurst++;
                }
              

            }
 
        }
      
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
    public void AttackMechanism()
    {
        float x = Random.Range(8, -8);
    
        Vector2 TargetDirection = (truck.position-FiringPoint.transform.position).normalized;
        Vector2 direction = (truck.position - FiringPoint.transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
       float spreadangle = Random.Range(-BulletSpread, BulletSpread);
        Quaternion spread = Quaternion.Euler(0f, 0f, spreadangle);
        Vector2 spreaddirection = spread * TargetDirection;
        GameObject A10Projectile = Instantiate(Bullets, FiringPoint.transform.position, Quaternion.Euler(180f,0f,-angle));
        Rigidbody2D rb = A10Projectile.GetComponent<Rigidbody2D>();
        rb.velocity = spreaddirection * BulletSpeed;

       
    }
}
