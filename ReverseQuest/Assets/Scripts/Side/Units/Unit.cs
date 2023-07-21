using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform enemy;

    public LayerMask whatIsGround, WhatIsEnemy;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool enemyInSightRange, enemyInAttackRange;

    public float distance;
    public float nearestDistance = float.MaxValue;

    private AnimationManager _animationManager;
    private FindUnitsToAttack _findNearestObject;

    private bool allNull;

    private void Start()
    {
        _animationManager = GetComponent<AnimationManager>();
        agent = GetComponent<NavMeshAgent>();
        _findNearestObject = FindObjectOfType<FindUnitsToAttack>();
        FindNearestEnemy(_findNearestObject.humanWarriors);
    }

    private void Update()
    {
        FindNearestEnemy(_findNearestObject.humanWarriors);

        //Check for sight and attack range
        enemyInSightRange = Physics.CheckSphere(transform.position, sightRange, WhatIsEnemy);
        enemyInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatIsEnemy);

        if(!enemyInSightRange && !enemyInAttackRange && !allNull)
        {
            Idle();
        }

        if (!enemyInSightRange && !enemyInAttackRange && allNull)
        {
            _animationManager.VictoryAnim();
        }

        if (enemyInSightRange && !enemyInAttackRange)
        {
            GlobalVars.canMove = true;
            ChaseEnemy();
        }

        if(enemyInSightRange && enemyInAttackRange)
        {
            GlobalVars.canMove = false;
            AttackEnemy();
        }
    }

    private void Idle()
    {
        _animationManager.IdleAnim();
    }

    private void ChaseEnemy()
    {
        _animationManager.RunAnim();
        agent.SetDestination(enemy.position);
    }

    private void AttackEnemy()
    {
        //Make sure Unit doesn't move anymore
        agent.SetDestination(transform.position);
        transform.LookAt(enemy);

        if (!alreadyAttacked)
        {
            _animationManager.AttackAnim();

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
        _animationManager.IdleAnim();
    }

    private void FindNearestEnemy(List<GameObject> listOfEnemies)
    {
        allNull = listOfEnemies.All(item => item == null);

        if(allNull)
        {
            return;
        }

        // Filter out null elements from the list
        listOfEnemies = listOfEnemies.Where(enemy => enemy != null).ToList();

        for (int i = 0; i < listOfEnemies.Count; ++i)
        {
            sightRange = Vector3.Distance(transform.position, listOfEnemies[i].transform.position);

            if (sightRange < nearestDistance)
            {
                enemy = listOfEnemies[i].transform;
                sightRange = nearestDistance;
            }            
        }
    }
}
