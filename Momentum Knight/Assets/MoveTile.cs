using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTile : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public GameObject tile;
    private bool isMoving;
    private float offsetMagnitude;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tile.transform.position += Vector3.up * 0.05f;
            Debug.Log(collision.otherRigidbody.velocity);
        }
    }
}
