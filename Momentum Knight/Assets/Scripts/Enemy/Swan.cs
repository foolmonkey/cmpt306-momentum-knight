using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Swan : MonoBehaviour
{
    public float WaitTime;
    public float ReWaitTime;
    public float WaitTimeEnd;
    public float Speed;

    public Vector2 MoveRandom;
    public Transform TheStarPoint;
    public Transform TheEndPoint;
    public Transform TheTargetPoint;
    void Start()
    {

    }

    void Update()
    {
        if (WaitTime >= 0)
        {
            if (WaitTime > WaitTimeEnd)
            {
                MoveRandom = new Vector2(UnityEngine.Random.Range(TheStarPoint.position.x, TheEndPoint.position.x), UnityEngine.Random.Range(TheStarPoint.position.y, TheEndPoint.position.y));
                WaitTime = ReWaitTime;
            }
            TheTargetPoint.position = MoveRandom;
            transform.position = Vector2.MoveTowards(transform.position, TheTargetPoint.position, Speed * Time.deltaTime);
            WaitTime += Time.deltaTime;
        }
        else
        {
            WaitTime += Time.deltaTime;
        }
    }
}