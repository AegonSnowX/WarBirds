using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class VehicleMovement : MonoBehaviour
{
    [SerializeField] float MovementSpeed;
    [SerializeField] Vector2 moveVelocity;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer truck;
    [SerializeField] float lastMoveX = 1f;
    [SerializeField] GameObject turretStand;
    [SerializeField] SpriteRenderer turretSprite ;
    [SerializeField] GameObject AntiAirRocket;
    [SerializeField] Aimpoint aimPoint;
    [SerializeField] GameObject turret; // Reference to the turret
    [SerializeField] float turretOffsetXRight = -3.9f; // Adjust this value for right facing
    [SerializeField] float turretOffsetXLeft = 3.9f; // Adjust this value for left facing

    
    public float BulletSpeed = 35f;
   
    public GameObject firingPoint;
   

    void Start()
    {

    }

    void Update()
    {
        TruckMovement();
        AimTurret();
       FiringMechanism();
       
    }

    public void TruckMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        moveVelocity = new Vector2(moveX * MovementSpeed, rb.velocity.y);

        if (moveX != 0)
        {
            lastMoveX = moveX;
        }

        // Flip the sprite based on the last movement direction
        if (lastMoveX > 0)
        {
            truck.flipX = true; // Facing right
            AdjustTurretPosition(true); // Adjust turret position when facing right
        }
        else if (lastMoveX < 0)
        {
            truck.flipX = false; // Facing left
            AdjustTurretPosition(false); // Adjust turret position when facing left
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveVelocity;
    }

    void AdjustTurretPosition(bool facingRight)
    {
        // Adjust the turret's local position to remain at the back of the truck
        float turretOffsetX = facingRight ? turretOffsetXRight : turretOffsetXLeft;
        turret.transform.localPosition = new Vector3(turretOffsetX, turret.transform.localPosition.y, turret.transform.localPosition.z);

        // Adjust the position of Turret Stand 
        turretStand.transform.localPosition = new Vector3(turretOffsetX, turretStand.transform.localPosition.y, turretStand.transform.localPosition.z);


    }
    float angle;
    void AimTurret()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert mouse position to world coordinates
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mouseWorldPosition.z = 0; // Ensure z position is the same as the turret's

        // Calculate direction from turret to mouse position
        Vector3 direction = mouseWorldPosition - turret.transform.position;
       
        // Calculate rotation angle
          angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        
/*
        // Flip the turret sprite based on the angle
        if (angle > 90 && angle < 270)
        {
           // turretSprite.flipY = true;
            angle = 180 - angle;
        }
        else
        {
            turretSprite.flipY = false;
        }
*/
        // Rotate the turret to face the mouse position
        turret.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    public void FiringMechanism()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(AntiAirRocket, firingPoint.transform.position, Quaternion.Euler(0f, 0f, angle - 45));
            Vector3 aimingVector = aimPoint.gameObject.transform.position - firingPoint.transform.position;
            aimingVector.Normalize();
            projectile.GetComponent<Rigidbody2D>().AddForce(aimingVector * BulletSpeed);
        }
    }
    
   

}

