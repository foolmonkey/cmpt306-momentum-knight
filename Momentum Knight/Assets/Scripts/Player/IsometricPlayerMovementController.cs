using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IsometricPlayerMovementController : MonoBehaviour
{
    // player manager
    PlayerManager playerManager;

    //Variables required to calculate momentum
    public float maxSpeed = 2.0f;
    public float currSpeed = 1.4f;
    public float acceleration = 0.1f;
    public Boolean ice = false;
    public float maxVelocity = 4.0f;

    //Renderer that will assosicate direction with proper sprite and animation
    IsometricCharacterRenderer isoRenderer;

    //Ridgid body for player
    Rigidbody2D rbody;

    //Inputs grabbed in update
    Vector2 movement;
    Vector2 previousMovement;

    private void Awake()
    {
        playerManager = (PlayerManager)FindObjectOfType(typeof(PlayerManager));

        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }


    // Update is called once per frame
    void Update()
    {

        previousMovement = movement;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    public void FixedUpdate()
    {
        //Getting current position and user inputs 
        Vector2 currentPos = rbody.position;
        float currSpeedDir = currSpeed * 0.5f;
        Vector3 prevVelocity = rbody.velocity;
        float accelerationAdjusted = acceleration;


        bool wasUp = prevVelocity.y > 0.5;
        bool wasDown = prevVelocity.y < -0.5;
        bool wasRight = prevVelocity.x > 0.5;
        bool wasLeft = prevVelocity.x < -0.5;


        if (currSpeed > maxSpeed)
        {
            accelerationAdjusted = acceleration / 5f;
        }

        if (movement == new Vector2(0, 0))
        {
            // detects player movement
            playerManager.playerIsMoving = false;

            if (!ice)
            {
                rbody.velocity *= 0.75f;

            }
            else
            {
                rbody.velocity *= 0.99f;
            }
        }
        else
        {
            // detects player movement
            playerManager.playerIsMoving = true;
            if (currSpeed < maxSpeed)
            {
                currSpeed *= 1.05f;
            }


            if (previousMovement.x != movement.x)
            {
                previousMovement.x = 0;
                rbody.velocity = new Vector2(0, previousMovement.y);
            }


            if (previousMovement.y != movement.y)
            {
                previousMovement.y = 0;
                rbody.velocity = new Vector2(previousMovement.x, 0);
            }

            if (movement.x > 0 && Math.Abs(rbody.velocity.x) < maxVelocity)
            {

                rbody.AddForce(transform.right * currSpeed);
            }
            else if (movement.x < 0 && Math.Abs(rbody.velocity.x) < maxVelocity)
            {

                rbody.AddForce(transform.right * -currSpeed);
            }

            if (movement.y > 0 && Math.Abs(rbody.velocity.y) < (maxVelocity * 0.5f))
            {

                rbody.AddForce(transform.up * (currSpeed * 0.5f));
            }
            else if (movement.y < 0 && Math.Abs(rbody.velocity.y) < (maxVelocity * 0.5f))
            {

                rbody.AddForce(transform.up * (-currSpeed * 0.5f));
            }

        }
        isoRenderer.SetDirection(movement);
    }

    public void setPlayerMovement(Boolean isMovingValue)
    {
        playerManager.playerIsMoving = isMovingValue;
    }
    
}
