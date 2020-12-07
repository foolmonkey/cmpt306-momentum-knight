using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
enum PunishState
{
    Idle,
    Tracking,
    Holding,
    Attack
}
public class PunishAI : MonoBehaviour
{
    public bool playerIsEnter;
    public float speed;
    public float SafeDistance;
    public float Trackingdistance;
    public float Attackdistance;
    public Transform point;
    private Transform Player;
    private PunishState enemyState;
    private AIPath AIPath;
    private AIDestinationSetter AIDestinationSetter;



    void Start()
    {
        AIPath = GetComponent<AIPath>();
        AIDestinationSetter = GetComponent<AIDestinationSetter>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        AIPath.maxSpeed = 0;
        AIPath.maxAcceleration = 0.01f;
        enemyState = PunishState.Idle;
    }
    void Update()
    {
        switch (enemyState)
        {
            case PunishState.Idle:
                Idle();
                break;
            case PunishState.Tracking:
                Tracking();
                break;
            case PunishState.Holding:
                Holding();
                break;
            case PunishState.Attack:
                Attack();
                break;
            default:
                break;
        }

    }

    public void Idle()
    {
        if (Vector3.Distance(point.position, Player.position) > SafeDistance)
        {
            AIPath.maxSpeed = speed;
            AIPath.maxAcceleration = 100;
            enemyState = PunishState.Tracking;
        }
    }
    public void Tracking()
    {
        if (Vector3.Distance(point.position, Player.position) > SafeDistance && Vector3.Distance(transform.position, Player.position) < Trackingdistance && Vector3.Distance(transform.position, Player.position) > Attackdistance)
        {
            AIPath.maxSpeed = 0;
            enemyState = PunishState.Holding;
        }
        else if (Vector3.Distance(point.position, Player.position) > SafeDistance && Vector3.Distance(transform.position, Player.position) < Attackdistance)
        {
            AIPath.maxSpeed = 2 * speed;
            enemyState = PunishState.Attack;
        }
    }
    public void Holding()
    {
        if (Vector3.Distance(point.position, Player.position) > SafeDistance && Vector3.Distance(transform.position, Player.position) > Trackingdistance)
        {
            AIPath.maxSpeed = speed;
            enemyState = PunishState.Tracking;
        }
        else if (Vector3.Distance(point.position, Player.position) > SafeDistance && Vector3.Distance(transform.position, Player.position) < Attackdistance)
        {
            AIPath.maxSpeed = 2 * speed;
            enemyState = PunishState.Attack;
        }

    }
    public void Attack()
    {
        if (Vector3.Distance(point.position, Player.position) > SafeDistance && Vector3.Distance(transform.position, Player.position) > Trackingdistance)
        {
            AIPath.maxSpeed = 0;
            enemyState = PunishState.Idle;
        }
    }
}
