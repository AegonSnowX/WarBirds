using UnityEngine;

public class BombLogic : MonoBehaviour
{
    private Rigidbody2D rb;
    public float torqueAmount = 0.2f;  // Adjust this value to control the rotation speed
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

        rb.AddTorque(torqueAmount);
    }




    void FixedUpdate()
    {

        rb.AddTorque(-torqueAmount * Time.fixedDeltaTime);

    }
}
