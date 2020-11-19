using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
enum EnemyState
{
    Idle,
    Tracking,
    Attack
}
public class Enemysteps : MonoBehaviour
{
    public Transform enemyModel;
    public bool playerIsEnter;
    public float speed;
    public float WaitTime;
    private Transform playerTran;
    private EnemyState enemyState;
    private AIPath AIPath;
    private AIDestinationSetter AIDestinationSetter;


    void Start()
    {
        AIPath = GetComponent<AIPath>();
        AIDestinationSetter = GetComponent<AIDestinationSetter>();
        playerTran = GameObject.FindGameObjectWithTag("Player").transform;
        enemyState = EnemyState.Idle;
        AIPath.maxSpeed = 0;
    }
    void Update()
    {
        if (AIPath.desiredVelocity.x >= 0.01f)
        {
            enemyModel.localScale = new Vector3(8, 8, 8);
        }
        else if (AIPath.desiredVelocity.x <= 0.01f)
        {
            enemyModel.localScale = new Vector3(4, 4, 4);
        }
        switch (enemyState)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Tracking:
                Tracking();
                break;
            default:
                break;
        }

    }
    public void Idle()
    {
        if (playerIsEnter)
        {
            AIPath.maxSpeed = speed;
            enemyState = EnemyState.Tracking;
        }
    }
    public void Tracking()
    {
        if (Vector3.Distance(transform.position, playerTran.position) < 1.0f)
        {
            AIPath.maxSpeed = 0;
            //AIDestinationSetter.target = null;
            WaitTime += Time.deltaTime;
            enemyState = EnemyState.Idle;
        }

    }
}
