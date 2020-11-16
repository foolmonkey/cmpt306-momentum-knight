using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemypickupitem : MonoBehaviour
{
    public Transform target;
    public bool isFollow = false;
    public float followDistance = 0.5f;
    public float speedToFollow = 0.5f;
    private bool hasCollided = false;

    private void Awake()
    {
        target = GameObject.FindWithTag("Goldeater").GetComponent<Transform>();
        if (gameObject.tag == "Currency")
        {
            isFollow = true;
        }
    }

    private void RemoveItem()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        float distanceFromTarget = Vector3.Distance(transform.position, target.position);

        if (isFollow)
        {
            if (distanceFromTarget < 0.2f)
            {
                RemoveItem();
            }
            else if (distanceFromTarget < followDistance || hasCollided)
            {
                // change follow speed when too far
                if (distanceFromTarget > 2)
                {
                    speedToFollow += speedToFollow / 3;
                }

                hasCollided = true;
                transform.position = Vector3.MoveTowards(transform.position, target.position, speedToFollow * Time.deltaTime);
            }
        }
    }
}
