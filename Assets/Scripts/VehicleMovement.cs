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
    [SerializeField] SpriteRenderer turretSprite;
    [SerializeField] GameObject turret; // Reference to the turret
    [SerializeField] float turretOffsetXRight = -3.9f; // Adjust this value for right facing
    [SerializeField] float turretOffsetXLeft = 3.9f; // Adjust this value for left facing
    [SerializeField] SpriteRenderer turretHead;
    public float angle { get; private set; }
    void Start()
    {

    }

    void Update()
    {
        TruckMovement();
        AimTurret();
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

    void AimTurret()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mouseWorldPosition.z = 0;
        Vector3 direction = mouseWorldPosition - turret.transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        if (angle > 0)
        {
            //turretHead.flipY = false also Works but collider won't change, only visual
            turret.transform.localScale = new Vector3(0.459184f, 0.5156348f, 1);
            turret.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
        if (angle > 90)
        {
            //turretHead.flipY = true also Works but collider won't change, only visual
            turret.transform.localScale = new Vector3(0.459184f, -0.5156348f, 1);
            turret.transform.rotation = Quaternion.Euler(0, 0f, angle);
        }


    }
}