using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWhenTriggered : MonoBehaviour
{
    public string TriggerObjectName = "BorderLeft";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy Plane"))
        {
            Rigidbody2D collisionRb = collision.gameObject.GetComponent<Rigidbody2D>();
            
            GameManager.Instance.Flip(collision.gameObject);
            if (gameObject.name == TriggerObjectName)
                collisionRb.velocity = collision.gameObject.transform.TransformDirection(Vector2.right);
            else
                collisionRb.velocity = collision.gameObject.transform.TransformDirection(Vector2.left);
        }

    }
}
