using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public PlayerDamageHandler parentDamageHandler;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy Bullet"))
        {
            transform.parent.GetComponent<PlayerDamageHandler>().OnTriggerActivated(gameObject, collision);
        }
    }
}
