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
    public float StartTime;
    public float Trackingdistance;
    public float Attackdistance;
    private Transform playerTran;
    private PunishState enemyState;
    private AIPath AIPath;
    private AIDestinationSetter AIDestinationSetter;

    void Start()
    {
        AIPath = GetComponent<AIPath>();
        AIDestinationSetter = GetComponent<AIDestinationSetter>();
        playerTran = GameObject.FindGameObjectWithTag("Player").transform;
        enemyState = PunishState.Idle;
        AIPath.maxSpeed = 0;
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
        if (playerIsEnter && Time.time > StartTime)
        {
            AIPath.maxSpeed = speed;
            enemyState = PunishState.Tracking;
        }
    }
    public void Tracking()
    {
        if (Vector3.Distance(transform.position, playerTran.position) < Trackingdistance && Vector3.Distance(transform.position, playerTran.position) > Attackdistance)
        {
            AIPath.maxSpeed = 0;
            enemyState = PunishState.Holding;
        }
        else if (Vector3.Distance(transform.position, playerTran.position) < Attackdistance)
        {
            AIPath.maxSpeed = 2 * speed;
            enemyState = PunishState.Attack;
        }
    }
    public void Holding()
    {
        if (Vector3.Distance(transform.position, playerTran.position) > Trackingdistance)
        {
            AIPath.maxSpeed = speed;
            enemyState = PunishState.Tracking;
        }
        else if (Vector3.Distance(transform.position, playerTran.position) < Attackdistance)
        {
            AIPath.maxSpeed = 2 * speed;
            enemyState = PunishState.Attack;
        }

    }
    public void Attack()
    {
        {
            AIPath.maxSpeed = speed;
        }
    }

}
