using UnityEngine;

public class HelicopterLogic : MonoBehaviour
{
    [SerializeField] float Speed = 5.0f;
    [SerializeField] GameObject Helicopter;
    private bool movingRight = true;

    void Update()
    {
        MoveHelicopter();
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
}
