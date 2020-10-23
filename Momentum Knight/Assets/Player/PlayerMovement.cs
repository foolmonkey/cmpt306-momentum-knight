using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb; 
    public float speed;
    public float jumpingForce;

        void Start(){
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            Movement();
            Jump();
        }  

        void Movement(){
            float xChange = Input.GetAxisRaw("Horizontal"); 
            float movementOffset = xChange * speed; 
            rb.velocity = new Vector2(movementOffset, rb.velocity.y); 
        }

        void Jump() { 
            if (Input.GetKeyDown(KeyCode.Space)) { 
                rb.velocity = new Vector2(rb.velocity.x, jumpingForce); 
            } 
        }
}
