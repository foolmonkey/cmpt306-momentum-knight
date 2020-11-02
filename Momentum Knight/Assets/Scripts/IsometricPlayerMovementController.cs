using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovementController : MonoBehaviour
{

    //Variables required to calculate momentum
    public float maxSpeed = 5.0f;
    public float currSpeed = 1.0f;

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

        //up and to the right
        if (inputVector == new Vector2(1,1))
        {
            rbody.AddForce(transform.up * currSpeed);
            rbody.AddForce(transform.right * currSpeed);

            isoRenderer.SetDirection(movement);
            if (currSpeed < maxSpeed)
            {
                currSpeed += 0.05f;
            }
        }

        //move down and to the left
        if (inputVector == new Vector2(-1, -1))
        {
            rbody.AddForce(transform.up * -currSpeed);
            rbody.AddForce(transform.right * -currSpeed);

            isoRenderer.SetDirection(movement);
            if (currSpeed < maxSpeed)
            {
                currSpeed += 0.05f;
            }
        }

        //move down and to the right
        if (inputVector == new Vector2(1, -1))
        {
            rbody.AddForce(transform.up * -currSpeed);
            rbody.AddForce(transform.right * currSpeed);

            isoRenderer.SetDirection(movement);
            if (currSpeed < maxSpeed)
            {
                currSpeed += 0.05f;
            }
        }

        //move up and to the left
        if (inputVector == new Vector2(-1, 1))
        {
            rbody.AddForce(transform.up * currSpeed);
            rbody.AddForce(transform.right * -currSpeed);

            isoRenderer.SetDirection(movement);
            if (currSpeed < maxSpeed)
            {
                currSpeed += 0.05f;
            }
        }

        //move to the left
        if (inputVector == new Vector2(-1, 0))
        {
            rbody.AddForce(transform.right * -currSpeed);

            isoRenderer.SetDirection(movement);
            if (currSpeed < maxSpeed)
            {
                currSpeed += 0.05f;
            }
        }

        //move up
        if (inputVector == new Vector2(0, 1))
        {
            rbody.AddForce(transform.up * currSpeed);

            isoRenderer.SetDirection(movement);
            if (currSpeed < maxSpeed)
            {
                currSpeed += 0.05f;
            }
        }

        //move right
        if (inputVector == new Vector2(1, 0))
        {
            rbody.AddForce(transform.right * currSpeed);

            isoRenderer.SetDirection(movement);
            if (currSpeed < maxSpeed)
            {
                currSpeed += 0.05f;
            }
        }

        //move down
        if (inputVector == new Vector2(0, -1))
        {
            rbody.AddForce(transform.up * -currSpeed);

            isoRenderer.SetDirection(movement);
            if (currSpeed < maxSpeed)
            {
                currSpeed += 0.05f;
            }
           
        }

        //move down
        if (inputVector == new Vector2(0, 0))
        {

            isoRenderer.SetDirection(movement);
            if (currSpeed > 0)
            {
                currSpeed -= 0.25f;
            }
        }



        //Movement animation
        /*
        isoRenderer.SetDirection(movement);
        rbody.MovePosition(newPos);
        */

    }
}
