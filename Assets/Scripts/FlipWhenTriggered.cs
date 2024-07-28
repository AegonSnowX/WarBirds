using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWhenTriggered : MonoBehaviour
{
    public string TriggerObjectName = "BorderLeft";
    private Dictionary<GameObject, Vector2> originalVelocities = new Dictionary<GameObject, Vector2>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy Plane"))
        {
            Rigidbody2D collisionRb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (!originalVelocities.ContainsKey(collision.gameObject))
            {
                originalVelocities[collision.gameObject] = collisionRb.velocity;
            }


            GameManager.Instance.Flip(collision.gameObject);

            Vector2 originalVelocity = originalVelocities[collision.gameObject];

            if (gameObject.name == TriggerObjectName)
            {
                collisionRb.velocity = collision.gameObject.transform.TransformDirection(Vector2.right) * originalVelocity.magnitude; 
            }
             
            else
            {
                collisionRb.velocity = collision.gameObject.transform.TransformDirection(Vector2.left) * originalVelocity.magnitude;
            }

        }

    }
}
