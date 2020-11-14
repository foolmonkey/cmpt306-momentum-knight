﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Transform target;
    public bool isFollow = false;
    public float followDistance = 1.5f;
    public float speedToFollow = 1.0f;
    private bool hasCollided = false;

    private void Awake()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
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
            if (distanceFromTarget < 0.1f)
            {
                RemoveItem();
            }
            else if (distanceFromTarget < followDistance || hasCollided)
            {
                hasCollided = true;
                transform.position = Vector3.MoveTowards(transform.position, target.position, speedToFollow * Time.deltaTime);
            }
        }
    }
}
