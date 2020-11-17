using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public PlayerManager playerManager;
    public Transform target;
    public bool isFollow = false;
    public float followDistance = 1.5f;
    public float speedToFollow = 1.0f;
    private bool hasCollided = false;

    private bool pickedUp;

    private void Awake()
    {
        pickedUp = false;

        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        if (gameObject.tag == "Currency")
        {
            isFollow = true;
        }
    }

    private void RemoveItem()
    {
        switch (gameObject.tag)
        {
            case "Currency":
                pickedUp = playerManager.addCoin();
                break;
            default:
                break;
        }

        if (pickedUp)
        {
            Destroy(gameObject);
        }
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
