using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    // player manager
    PlayerManager playerManager;
    Rigidbody2D rbody;

    //Inputs grabbed in update
    Vector2 movement;
    Vector2 previousMovement;

    public float dashSpeed;

    public int manaCost;

    private void Awake()
    {
        playerManager = (PlayerManager)FindObjectOfType(typeof(PlayerManager));

        rbody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        previousMovement = movement;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PerformDash();
        }
    }

    private void PerformDash()
    {

        if (playerManager)
        {
            if (playerManager.currentMana >= manaCost)
            {
                previousMovement = rbody.velocity;

                float velocityX = rbody.velocity.x;
                float velocityY = rbody.velocity.y;

                if (movement.x < 0)
                {
                    rbody.AddForce(transform.right * -2.0f * dashSpeed);
                }
                else
                {
                    rbody.AddForce(transform.right * 2.0f * dashSpeed);
                }

                if (movement.y < 0)
                {
                    rbody.AddForce(transform.up * -2.0f * (dashSpeed / 2.0f));
                }
                else
                {
                    rbody.AddForce(transform.up * 2.0f * (dashSpeed / 2.0f));
                }


                playerManager.manaDown(manaCost);
            }
        }
    }
}
