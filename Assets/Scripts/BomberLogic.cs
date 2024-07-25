using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberLogic : MonoBehaviour
{
    [SerializeField] float FlightSpeed = 1.2f;
    [SerializeField] GameObject Bomb1Prefab;
    [SerializeField] Rigidbody2D bomberRb;
    private float bombDropInterval;
    private float timeSinceLastBomb;
    [SerializeField] GameObject Bomb2Prefab;
    [SerializeField] SpriteRenderer plane;
    [SerializeField] bool movingRight = true;



    void Start()
    {
        SetRandomBombDropInterval();
        timeSinceLastBomb = 0f;
    }

    void Update()
    {
        //Movement is done on GameManagment
        //BomberMovement();
        HandleBombDropping();
    }

    public void BomberMovement()
    {
        if (transform.position.x > -16 && transform.position.x < 16)
        {
            // Continue moving in the current direction
            bomberRb.velocity = new Vector2(movingRight ? FlightSpeed : -FlightSpeed, bomberRb.velocity.y);
            
        }
        else
        {
            // Change direction when hitting the boundary
            movingRight = !movingRight;
            bomberRb.velocity = new Vector2(movingRight ? FlightSpeed : -FlightSpeed, bomberRb.velocity.y);
            plane.flipX = !movingRight; // Flip the sprite to face the new direction
        }
    }

    void HandleBombDropping()
    {

        timeSinceLastBomb += Time.deltaTime;
        if (timeSinceLastBomb >= bombDropInterval)
        {
            DropBomb();
            SetRandomBombDropInterval();
            timeSinceLastBomb = 0f;
        }
    } 

    void DropBomb() //Rewrok can be done on this function, Unecessary Repetition
    {
        int bombtype = Random.Range(1, 3);
        if ((bombtype == 1)&&(movingRight))
        // Instantiate a bomb at the bomber's position with the bomber's rotation
        {  
            GameObject bomb = Instantiate(Bomb1Prefab, transform.position, Quaternion.Euler(0, 0, 90));
            //SpriteRenderer bombsprite = bomb.GetComponent<SpriteRenderer>();



            // Set the bomb's initial velocity to match the bomber's velocity
            Rigidbody2D bombRb = bomb.GetComponent<Rigidbody2D>();
            if (bombRb != null)
            {
                bombRb.velocity = bomberRb.velocity;

            }
        }else if((bombtype == 1) && (!movingRight) && GameManager.Instance.isSpawnedRight)
        {
           
            GameObject bomb = Instantiate(Bomb1Prefab, transform.position, Quaternion.Euler(0, 0, 90));
            //SpriteRenderer bombsprite = bomb.GetComponent<SpriteRenderer>();
            //bombsprite.flipY = true;

            // Set the bomb's initial velocity to match the bomber's velocity
            Rigidbody2D bombRb = bomb.GetComponent<Rigidbody2D>();
            if (bombRb != null)
            {
                bombRb.velocity = bomberRb.velocity;

            }
        }



        else if((bombtype == 2) && (movingRight)) 

        {
            GameObject bomb = Instantiate(Bomb2Prefab, transform.position, Quaternion.Euler(0, 0, 90));

            // Set the bomb's initial velocity to match the bomber's velocity
            Rigidbody2D bombRb = bomb.GetComponent<Rigidbody2D>();
            if (bombRb != null)
            {
                bombRb.velocity = bomberRb.velocity;

            }
        }
        else if(bombtype == 2 && (!movingRight) && GameManager.Instance.isSpawnedRight)
        {
            GameObject bomb = Instantiate(Bomb2Prefab, transform.position, Quaternion.Euler(0, 0, 90));
            //SpriteRenderer bombsprite = bomb.GetComponent<SpriteRenderer>();
            //bombsprite.flipY = true;
            // Set the bomb's initial velocity to match the bomber's velocity
            Rigidbody2D bombRb = bomb.GetComponent<Rigidbody2D>();
            if (bombRb != null)
            {
                bombRb.velocity = bomberRb.velocity;

            }
        }


    }

    

    void SetRandomBombDropInterval()
    {
        // Set a random interval between 1 and 8 seconds
        bombDropInterval = Random.Range(1f, 8f);
    }
}
