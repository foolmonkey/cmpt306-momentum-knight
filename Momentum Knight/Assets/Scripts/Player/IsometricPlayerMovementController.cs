using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovementController : MonoBehaviour
{
    // player manager
    PlayerManager playerManager;

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
        playerManager = (PlayerManager)FindObjectOfType(typeof(PlayerManager));

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

        bool wasUp = prevVelocity.y > 0.5;
        bool wasDown = prevVelocity.y < -0.5;
        bool wasRight = prevVelocity.x > 0.5;
        bool wasLeft = prevVelocity.x < -0.5;

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

        if (currSpeed > 2)
        {
            accelerationAdjusted = acceleration / 5f;
        }

        if (inputVector == new Vector2(0, 0))
        {
            // detects player movement
            playerManager.playerIsMoving = false;
            if (!ice)
            {
                rbody.velocity = new Vector3(0, 0, 0);
            }

            if (currSpeed > 1)
            {
                currSpeed -= accelerationAdjusted * 2f;
            }
        }
        else
        {
            // detects player movement
            playerManager.playerIsMoving = true;

            //up and to the right
            if (inputVector == new Vector2(1, 1))
            {
                if ((!ice && (rbody.velocity.x < 0)) || rbody.velocity.y < 0)
                {
                    rbody.velocity = new Vector2(0, 0);
                }

                rbody.velocity = new Vector2(Math.Abs(prevVelocity.x), Math.Abs(prevVelocity.y));

                // constraints for adding force in current direction
                if (((wasRight && wasUp) && prevVelocity.magnitude < maxSpeed) || !(wasRight && wasUp) || rbody.velocity.magnitude < 0.5)
                {
                    if (rbody.velocity.magnitude < 1)
                    {
                        rbody.AddForce(transform.up * currSpeedDir);
                    }
                    rbody.AddForce(transform.up * currSpeedDir);
                    rbody.AddForce(transform.right * currSpeed);
                }
            }
            //move down and to the left
            else if (inputVector == new Vector2(-1, -1))
            {
                if ((!ice && (rbody.velocity.x > 0)) || rbody.velocity.y > 0)
                {
                    rbody.velocity = new Vector2(0, 0);
                }

                rbody.velocity = new Vector2(-Math.Abs(prevVelocity.x), -Math.Abs(prevVelocity.y));

                if (((wasLeft && wasDown) && prevVelocity.magnitude < maxSpeed) || !(wasLeft && wasDown) || rbody.velocity.magnitude < 0.5)
                {
                    if (rbody.velocity.magnitude < 1)
                    {
                        rbody.AddForce(transform.up * -currSpeedDir);
                        rbody.AddForce(transform.right * -currSpeed);
                    }
                    rbody.AddForce(transform.up * -currSpeedDir);
                    rbody.AddForce(transform.right * -currSpeed);
                    Debug.Log("hi");
                }
            }

            //move down and to the right
            else if (inputVector == new Vector2(1, -1))
            {
                if ((!ice && (rbody.velocity.x < 0)) || rbody.velocity.y > 0)
                {
                    rbody.velocity = new Vector2(0, 0);
                }

                rbody.velocity = new Vector2(Math.Abs(prevVelocity.x), -Math.Abs(prevVelocity.y));

                if (((wasRight && wasDown) && prevVelocity.magnitude < maxSpeed) || !(wasRight && wasDown) || rbody.velocity.magnitude < 0.5)
                {
                    if (rbody.velocity.magnitude < 1)
                    {
                        rbody.AddForce(transform.up * -currSpeedDir);
                        rbody.AddForce(transform.right * currSpeed);
                    }
                    rbody.AddForce(transform.up * -currSpeedDir);
                    rbody.AddForce(transform.right * currSpeed);
                }
            }

            //move up and to the left
            else if (inputVector == new Vector2(-1, 1))
            {
                if ((!ice && (rbody.velocity.x > 0)) || rbody.velocity.y < 0)
                {
                    rbody.velocity = new Vector2(0, 0);
                }

                rbody.velocity = new Vector2(-Math.Abs(prevVelocity.x), Math.Abs(prevVelocity.y));

                if (((wasLeft && wasUp) && prevVelocity.magnitude < maxSpeed) || !(wasLeft && wasUp) || rbody.velocity.magnitude < 0.5)
                {
                    if (rbody.velocity.magnitude < 1)
                    {
                        rbody.AddForce(transform.up * currSpeed);
                        rbody.AddForce(transform.right * -currSpeed);
                    }

                    rbody.AddForce(transform.up * currSpeed);
                    rbody.AddForce(transform.right * -currSpeed);
                }
            }

            //move to the left
            else if (inputVector == new Vector2(-1, 0))
            {
                if ((!ice && (rbody.velocity.x > 0)) || Math.Abs(rbody.velocity.y) > 0)
                {
                    rbody.velocity = new Vector2(0, 0);
                }

                // rbody.velocity = new Vector2(-Math.Abs(prevVelocity.magnitude), 0);

                if (prevVelocity.magnitude < maxSpeed)
                {
                    if (rbody.velocity.magnitude < 1)
                    {
                        rbody.AddForce(transform.right * -currSpeed);
                    }
                    rbody.AddForce(transform.right * -currSpeed);
                }
            }

            //move up
            else if (inputVector == new Vector2(0, 1))
            {
                if ((!ice && (rbody.velocity.y < 0)) || Math.Abs(rbody.velocity.x) > 0)
                {
                    rbody.velocity = new Vector2(0, 0);
                }

                // rbody.velocity = new Vector2(0, Math.Abs(prevVelocity.magnitude));

                if (prevVelocity.magnitude < maxSpeed)
                {
                    if (rbody.velocity.magnitude < 1)
                    {
                        rbody.AddForce(transform.up * currSpeed);
                    }
                    rbody.AddForce(transform.up * currSpeed);
                }
            }

            //move right
            else if (inputVector == new Vector2(1, 0))
            {
                if ((!ice && rbody.velocity.x < 0) || Math.Abs(rbody.velocity.y) > 0)
                {
                    rbody.velocity = new Vector2(0, 0);
                }

                // rbody.velocity = new Vector2(Math.Abs(prevVelocity.magnitude), 0);

                if (prevVelocity.magnitude < maxSpeed)
                {
                    if (rbody.velocity.magnitude < 1)
                    {
                        rbody.AddForce(transform.right * currSpeed);
                    }
                    rbody.AddForce(transform.right * currSpeed);
                }
            }

            //move down
            else if (inputVector == new Vector2(0, -1))
            {
                if ((!ice && (rbody.velocity.y > 0)) || Math.Abs(rbody.velocity.x) > 0)
                {
                    rbody.velocity = new Vector2(0, 0);
                }

                // rbody.velocity = new Vector2(0, -Math.Abs(prevVelocity.magnitude));

                if (prevVelocity.magnitude < maxSpeed)
                {
                    if (rbody.velocity.magnitude < 1)
                    {
                        rbody.AddForce(transform.up * -currSpeed);
                    }
                    rbody.AddForce(transform.up * -currSpeed);
                }
            }

            if (currSpeed < maxSpeed)
            {
                currSpeed += accelerationAdjusted;
            }
        }

        isoRenderer.SetDirection(movement);
    }
}
