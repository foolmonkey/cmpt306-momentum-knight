using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
enum SpeedState
{
    Idle,
    Tracking,
    Attack
}
public class Speedcheck : MonoBehaviour
{
    public bool playerIsEnter;
    public float Attackspeed;
    public float Trackingspeed;
    public float Trackingdistance;
    private Transform Player;
    private SpeedState enemyState;
    private AIPath AIPath;
    private AIDestinationSetter AIDestinationSetter;



    void Start()
    {
        AIPath = GetComponent<AIPath>();
        AIDestinationSetter = GetComponent<AIDestinationSetter>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        AIPath.maxSpeed = 0;
        enemyState = SpeedState.Idle;
    }
    void Update()
    {
        switch (enemyState)
        {
            case SpeedState.Idle:
                Idle();
                break;
            case SpeedState.Tracking:
                Tracking();
                break;
            case SpeedState.Attack:
                Attack();
                break;
            default:
                break;
        }

    }

    public void Idle()
    {
        if (playerIsEnter)
        {
            AIPath.maxSpeed = Attackspeed;
            enemyState = SpeedState.Tracking;
        }
    }
    public void Tracking()
    {
        if (Vector3.Distance(transform.position, Player.position) < Trackingdistance)
        {
            AIPath.maxSpeed = Attackspeed;
            enemyState = SpeedState.Attack;
        }
    }
    public void Attack()
    {
        if (Vector3.Distance(transform.position, Player.position) > Trackingdistance)
        {
            AIPath.maxSpeed = Trackingspeed;
            enemyState = SpeedState.Tracking;
        }
    }
}
