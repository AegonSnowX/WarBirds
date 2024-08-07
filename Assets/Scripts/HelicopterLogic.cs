using System;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class HelicopterLogic : MonoBehaviour
{
    [SerializeField] float Speed = 6.0f;
    [SerializeField] GameObject Helicopter;
    private bool movingRight = true;
    [SerializeField] GameObject Bullets;
    [SerializeField] GameObject firingpoint;
    private  Transform truck;
    [SerializeField] Rigidbody2D bulletrb;
    float BulletSpeed = 2f;
    float firingDelay = 10.5f;
    float fireRate = 0.15f;
    float bulletsFiredInBurst = 0;
    float bulletsPerBurst = 7;
    float nextFireTime = 0f;
    float spreadangle = 25f;
    float initialfiringwait = 0f;
    float BulletSpread=5f;
    


    private void Start()
    {
        truck = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        initialfiringwait += Time.deltaTime;
        if (initialfiringwait > 11)
        {
            if (bulletsFiredInBurst < bulletsPerBurst)
            {
                if (Time.time > nextFireTime)
                {
                    FiringMechanism();
                    nextFireTime = Time.time + fireRate;
                    bulletsFiredInBurst++;
                }
            }
            else if (Time.time > nextFireTime + firingDelay)
            {
                bulletsFiredInBurst = 0; // Reset the burst counter
            }
        }
        //MoveHelicopter();
    }

    private void MoveHelicopter()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
            Helicopter.transform.rotation = Quaternion.Euler(0f, 0f, 0f);


            if (transform.position.x >= GameManager.Instance.maxBorderX - 8.1f)
            {
                movingRight = false;
            }
        }
        else if (!movingRight)
        {
            transform.Translate(Vector3.left * Time.deltaTime * -Speed);
            Helicopter.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

            if (transform.position.x <= -GameManager.Instance.maxBorderX + 8.1f)
            {
                movingRight = true;

            }
        }
    }
    public void FiringMechanism()
    {
      
        if (truck != null)
        {
            
            Vector2 firingdirection = (truck.position - firingpoint.transform.position).normalized;
            Vector2 direction = (truck.position - firingpoint.transform.position);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            spreadangle = Random.Range(-BulletSpread, BulletSpread);
            Quaternion spread =Quaternion.Euler(0f,0f, spreadangle);
            Vector2 spreaddirection = spread * firingdirection;
            GameObject HelicopterProjectile = Instantiate(Bullets, firingpoint.transform.position,Quaternion.Euler(180f,0f,-angle));
            Rigidbody2D rb = HelicopterProjectile.GetComponent<Rigidbody2D>();
            rb.velocity = spreaddirection * BulletSpeed;
            Debug.Log("Angle =" + angle);
            
        }
    }    
}
