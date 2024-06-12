using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class VehicleMovement : MonoBehaviour
{
    public float MovementSpeed;
    private Vector2 moveVelocity;
    public Rigidbody2D rb;
    public SpriteRenderer truck;
    private float lastMoveX = 1f;

    public GameObject turret; // Reference to the turret
    public float turretOffsetXRight = -3.9f; // Adjust this value for right facing
    public float turretOffsetXLeft = 3.9f; // Adjust this value for left facing

    void Start()
    {
       
    }

    void Update()
    {
        TruckMovement();
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
    }
}
