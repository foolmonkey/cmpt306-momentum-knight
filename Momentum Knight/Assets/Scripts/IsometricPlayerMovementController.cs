using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovementController : MonoBehaviour
{

    //Variables required to calculate momentum
    public float movementSpeed = 1f;
    public float momentum = 1f;
    public float mass = 1f;

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
            rbody.AddForce(transform.up * 2);
            rbody.AddForce(transform.right * 2);

            isoRenderer.SetDirection(movement);
        }

        //move down and to the left
        if (inputVector == new Vector2(-1, -1))
        {
            rbody.AddForce(transform.up * -2);
            rbody.AddForce(transform.right * -2);

            isoRenderer.SetDirection(movement);
        }

        //move down and to the right
        if (inputVector == new Vector2(1, -1))
        {
            rbody.AddForce(transform.up * -2);
            rbody.AddForce(transform.right * 2);

            isoRenderer.SetDirection(movement);
        }

        //move up and to the left
        if (inputVector == new Vector2(-1, 1))
        {
            rbody.AddForce(transform.up * 2);
            rbody.AddForce(transform.right * -2);

            isoRenderer.SetDirection(movement);
        }

        //move to the left
        if (inputVector == new Vector2(-1, 0))
        {
            rbody.AddForce(transform.right * -2);

            isoRenderer.SetDirection(movement);
        }

        //move up
        if (inputVector == new Vector2(0, 1))
        {
            rbody.AddForce(transform.up * 2);

            isoRenderer.SetDirection(movement);
        }

        //move right
        if (inputVector == new Vector2(1, 0))
        {
            rbody.AddForce(transform.right * 2);

            isoRenderer.SetDirection(movement);
        }

        //move down
        if (inputVector == new Vector2(0, -1))
        {
            rbody.AddForce(transform.up * -2);

            isoRenderer.SetDirection(movement);
        }

        //move down
        if (inputVector == new Vector2(0, 0))
        {

            isoRenderer.SetDirection(movement);
        }



        //Movement animation
        /*
        isoRenderer.SetDirection(movement);
        rbody.MovePosition(newPos);
        */

        Debug.Log(movementSpeed);
    }
}
