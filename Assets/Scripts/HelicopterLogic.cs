using UnityEngine;

public class HelicopterLogic : MonoBehaviour
{
    [SerializeField] float Speed = 5.0f;
    [SerializeField] GameObject Helicopter;
    private bool movingRight = true;
    [SerializeField] GameObject Bullets;
    [SerializeField] GameObject firingpoint;
    float firingDelay = 0f;
    public VehicleMovement truck;
  float BulletSpeed = 5f;
   


    void Update()
    {
         MoveHelicopter();
        FiringMechanism();
    }

    private void Start()
    {

    }
    private void MoveHelicopter()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
            Helicopter.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            if (transform.position.x >= 8.1f)
            {
                movingRight = false;
            }
        }
        else if (!movingRight)
        {
            transform.Translate(Vector3.left * Time.deltaTime * -Speed);
            Helicopter.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

            if (transform.position.x <= -8.1f)
            {
                movingRight = true;

            }
        }
    }
    public void FiringMechanism()
    {/*
        firingDelay += Time.deltaTime;

        if (movingRight && (firingDelay >= 7)&&(Helicopter.transform.position.x<=-5))
        {
            Debug.Log("Initiating Firing");
            for (int i = 0; i < 7; i++)
            {
               GameObject HelicopterProjectile = Instantiate(Bullets, firingpoint.transform.position, Quaternion.Euler(180f, 0f, 180f));
                Vector3 target = truck.transform.position-firingpoint.transform.position;   
                target.Normalize();
                HelicopterProjectile.GetComponent<Rigidbody2D>().AddForce(target * BulletSpeed);
            }
            firingDelay = 0f;
        }*/          // So many issues needs debugging , trying something but didnt worked.
    }
}
