using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatcoin : MonoBehaviour
{
    public Transform target;
    public bool isFollow = false;
    private bool hasCollided = false;

    private void Awake()
    {
        target = GameObject.FindWithTag("coin").GetComponent<Transform>();
    }

    private void RemoveItem()
    {
        Destroy(target);
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
        }
    }
}
