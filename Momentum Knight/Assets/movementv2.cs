using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEditor;
using UnityEngine;

public class movementv2 : MonoBehaviour
{
    //This is for the specific character, mutable later on for different types of characters
    [Header("Character Attributes:")]
    public float MOVEMENT_SPEED_CAP = 10.0f;
    public float ACCELERATION = 10.0f;
    public float DEACCELERATION = 10.0f;
    
    [Header("Character Statistics:")]
    public Vector2 movementDirection;
    public float movementSpeed;

    [Header("References")]
    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Move();
    }

    void ProcessInputs()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (movementDirection.magnitude != 0)
        {
            movementSpeed = Mathf.Clamp(movementSpeed + ACCELERATION * Time.deltaTime, 0.0f, MOVEMENT_SPEED_CAP);
        }
        else if (movementDirection.magnitude == 0)
        {
            movementSpeed = Mathf.Clamp(movementSpeed - DEACCELERATION * Time.deltaTime, 0.0f, MOVEMENT_SPEED_CAP);
        }
        
    }
    void Move()
    {
        rb.velocity = movementDirection * movementSpeed;
    }

}
