using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AntiAirRocketExplosion : MonoBehaviour
{

    [SerializeField] GameObject ExplosionOfPlanes;
    private Transform enemy;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Destroy(collision.gameObject);
        enemy = collision.gameObject.GetComponent<Transform>();
        GameObject explosion = Instantiate(ExplosionOfPlanes, enemy.transform.position, Quaternion.identity);
        ExplosionDestroyer destroyer = explosion.AddComponent<ExplosionDestroyer>();
        destroyer.lifeSecondsLeft = 4;
        Destroy(gameObject);
        GameManager.Instance.enemyDestroyed();

    }
}

