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
public class EnemyAI : MonoBehaviour
{
    public Transform enemyModel;
    public bool playerIsEnter;
    public float speed;
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
        if(AIPath.desiredVelocity.x >= 0.01f)
        {
            enemyModel.localScale = new Vector3(1, 1, 1);
        }
        else if (AIPath.desiredVelocity.x <= 0.01f)
        {
            enemyModel.localScale = new Vector3(-1, 1, 1);
        }
        switch (enemyState)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Tracking:
                Tracking();
                break;
            case EnemyState.Attack:
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
            AIPath.maxSpeed = speed;
            //AIDestinationSetter.target = playerTran;
            enemyState = EnemyState.Tracking;
            enemyModel.GetComponent<Animator>().SetBool("walk", true);
        }
    }
    public void Tracking()
    {
        //Attack when you reach a certain distance
        if (Vector3.Distance(transform.position,playerTran.position)<1.0f)
        {
            AIPath.maxSpeed = 0;
            //AIDestinationSetter.target = null;
            enemyState = EnemyState.Attack;
            enemyModel.GetComponent<Animator>().SetBool("walk", false);
        }

    }
    public void Attack()
    {
        //Attack the player
        //If the distance gets farther, start chasing
        if (Vector3.Distance(transform.position, playerTran.position) > 3.0f)
        {
            AIPath.maxSpeed = speed;
            //AIDestinationSetter.target = playerTran;
            enemyState = EnemyState.Tracking;
            enemyModel.GetComponent<Animator>().SetBool("walk", true);
        }
    }
}
