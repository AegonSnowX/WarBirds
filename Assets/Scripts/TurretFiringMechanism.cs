using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TurretFiringMechanism : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject AntiAirRocket;
    public float BulletSpeed = 200;
    public GameObject firingPoint;
    [SerializeField] Aimpoint aimPoint;
    [SerializeField] VehicleMovement directionangle;
    public Aimpoint aimpoint;


    void Start()
    {
        aimpoint = GameObject.Find("AimPoint").GetComponent<Aimpoint>();
    }

    // Update is called once per frame
    void Update()
    {
        FiringMechanism();
    }
    public void FiringMechanism()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float angle = directionangle.angle;
            if (aimpoint.canFire)
            {
                GameObject projectile = Instantiate(AntiAirRocket, firingPoint.transform.position, Quaternion.Euler(0f, 0f, angle - 45));
                Vector3 aimingVector = aimPoint.gameObject.transform.position - firingPoint.transform.position;
                aimingVector.Normalize();
                projectile.GetComponent<Rigidbody2D>().AddForce(aimingVector * BulletSpeed);
            }
        }
    }


}