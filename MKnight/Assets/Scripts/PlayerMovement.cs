using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    [SerializeField] private float moveSpeed = 5.0f;
    
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        moveH = Input.GetAxisRaw("Horizontal") * moveSpeed;
        moveV = Input.GetAxisRaw("Vertical") * moveSpeed;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveH, moveV);
    }
}
