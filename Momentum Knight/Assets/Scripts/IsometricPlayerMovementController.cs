using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovementController : MonoBehaviour
{

    //Variables required to calculate momentum
    public float maxSpeed = 2.0f;
    public float currSpeed = 1.0f;
    public float acceleration = 0.1f;
    public Boolean ice = false;

    //Renderer that will assosicate direction with proper sprite and animation
    IsometricCharacterRenderer isoRenderer;
    
    //Ridgid body for player
    Rigidbody2D rbody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //Getting current position and user inputs 
        Vector2 currentPos = rbody.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float currSpeedDir = currSpeed * 0.5f;
        Vector3 prevVelocity = rbody.velocity;
        float accelerationAdjusted = acceleration;
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        /*
        //When the user gains momentum (moves diagonally) we want to increase their speed and keep it there
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        rbody.velocity = inputVector;

        //calculate movements
        movementSpeed = momentum / mass;
        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        */

        Vector2 movement = inputVector;

        if(currSpeed > 2)
        {
            accelerationAdjusted = acceleration / 5f;
        }

        if (inputVector == new Vector2(0, 0))
        {
            if (!ice)
            {
                rbody.velocity = new Vector3(0, 0, 0);
            }

            isoRenderer.SetDirection(movement);
            if (currSpeed > 1)
            {
                currSpeed -= acceleration * 2f;
            }
        }

        //up and to the right
        if (inputVector == new Vector2(1,1))
        {
            if (!ice && (rbody.velocity.x < 0 || rbody.velocity.y < 0))
            {
                rbody.velocity = new Vector2(0,0);
            }

            if (prevVelocity.magnitude < maxSpeed)
            {
                rbody.AddForce(transform.up * currSpeedDir);
                rbody.AddForce(transform.right * currSpeed);
            }

            isoRenderer.SetDirection(movement);
            if (currSpeed < maxSpeed)
            {
                currSpeed += accelerationAdjusted;
            }
        }

        //move down and to the left
        if (inputVector == new Vector2(-1, -1))
        {
            if (!ice && (rbody.velocity.x > 0 || rbody.velocity.y > 0))
            {
                rbody.velocity = new Vector2(0, 0);
            }

            if (prevVelocity.magnitude < maxSpeed)
            {
                rbody.AddForce(transform.up * -currSpeedDir);
                rbody.AddForce(transform.right * -currSpeed);
            }

            isoRenderer.SetDirection(movement);
            if (currSpeed < maxSpeed)
            {
                currSpeed += accelerationAdjusted;
            }
        }

        //move down and to the right
        if (inputVector == new Vector2(1, -1))
        {
            if (!ice && (rbody.velocity.x < 0 || rbody.velocity.y > 0))
            {
                rbody.velocity = new Vector2(0, 0);
            }

            rbody.AddForce(transform.up * -currSpeedDir);
            rbody.AddForce(transform.right * currSpeed);

            isoRenderer.SetDirection(movement);
            if (currSpeed < maxSpeed)
            {
                currSpeed += accelerationAdjusted;
            }
        }

        //move up and to the left
        if (inputVector == new Vector2(-1, 1))
        {
            if (!ice && (rbody.velocity.x > 0 || rbody.velocity.y < 0))
            {
                rbody.velocity = new Vector2(0, 0);
            }

            if (prevVelocity.magnitude < maxSpeed)
            {
                rbody.AddForce(transform.up * currSpeed);
                rbody.AddForce(transform.right * -currSpeed);
            }

            isoRenderer.SetDirection(movement);
            if (currSpeed < maxSpeed)
            {
                currSpeed += accelerationAdjusted;
            }
        }

        //move to the left
        if (inputVector == new Vector2(-1, 0))
        {
            if (!ice && (rbody.velocity.x > 0 || Math.Abs(rbody.velocity.y) > 0))
            { 
                rbody.velocity = new Vector2(0, 0);
            }

            if (prevVelocity.magnitude < maxSpeed)
            {
                rbody.AddForce(transform.right * -currSpeed);
            }

            isoRenderer.SetDirection(movement);
            if (currSpeed < maxSpeed)
            {
                currSpeed += accelerationAdjusted;
            }
        }

        //move up
        if (inputVector == new Vector2(0, 1))
        {
            if (!ice && (rbody.velocity.y < 0 || Math.Abs(rbody.velocity.x) > 0))
            {
                rbody.velocity = new Vector2(0, 0);
            }

            if (prevVelocity.magnitude < maxSpeed)
            {
                rbody.AddForce(transform.up * currSpeed);
            }

            isoRenderer.SetDirection(movement);
            if (currSpeed < maxSpeed)
            {
                currSpeed += accelerationAdjusted;
            }
        }

        //move right
        if (inputVector == new Vector2(1, 0))
        {
            if (!ice && (rbody.velocity.x < 0 || Math.Abs(rbody.velocity.y) > 0))
            {
                rbody.velocity = new Vector2(0, 0);
            }

            if (prevVelocity.magnitude < maxSpeed)
            {
                rbody.AddForce(transform.right * currSpeed);
            }

            isoRenderer.SetDirection(movement);

            if (currSpeed < maxSpeed)
            {
                currSpeed += accelerationAdjusted;
            }
        }

        //move down
        if (inputVector == new Vector2(0, -1))
        {
            if (!ice && (rbody.velocity.y > 0 || Math.Abs(rbody.velocity.x) > 0))
            {
                rbody.velocity = new Vector2(0, 0);
            }

            if (prevVelocity.magnitude < maxSpeed)
            {
                rbody.AddForce(transform.up * -currSpeed);
            }

            isoRenderer.SetDirection(movement);
            if (currSpeed < maxSpeed)
            {
                currSpeed += accelerationAdjusted;
            }  
        }

        //Movement animation
        /*
        isoRenderer.SetDirection(movement);
        rbody.MovePosition(newPos);
        */
    }
}
