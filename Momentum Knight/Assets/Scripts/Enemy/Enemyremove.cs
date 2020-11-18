using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyremove : MonoBehaviour
{
    public Transform target;
    public float destorydistance = 10f;
    private bool hasCollided = false;
    private void RemoveItem()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        float distanceFromTarget = Vector3.Distance(transform.position, target.position);

    if (distanceFromTarget > destorydistance)
    {
                RemoveItem();
    }
    }
}
