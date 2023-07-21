using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAI : MonoBehaviour
{
    private Transform castle;

    public Transform enemy;

    public NavMeshAgent agent;

    public LayerMask whatIsGround, WhatIsEnemy;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool enemyInSightRange, enemyInAttackRange;
    public Collider[] hitEnemies;

    public float distance, speed;
    public float nearestDistance = float.MaxValue;

    private AnimationManager _animationManager;
    void Start()
    {
        castle = GameObject.Find("Castle").transform;
        _animationManager = GetComponent<AnimationManager>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        enemyInSightRange = Physics.CheckSphere(transform.position, sightRange, WhatIsEnemy);
        enemyInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatIsEnemy);

        if(!enemyInAttackRange)
        {
            Move();
        }

        if (enemyInSightRange)
        {
            hitEnemies = Physics.OverlapSphere(transform.position, sightRange, WhatIsEnemy);
            if (hitEnemies.Length > 0)
            {
                enemy = hitEnemies[0].transform;
                distance = Vector3.Distance(transform.position, enemy.position);
            }
        }

        if (distance < attackRange && enemyInAttackRange)
        {
            AttackEnemy();
        }
    }

    private void Move()
    {
        agent.SetDestination(castle.position);
        //animationManager.RunAnim();        
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
}
