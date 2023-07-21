using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public abstract class BaseUnit : MonoBehaviour
{
    public NavMeshAgent agent;
    
    public Transform enemy;
    
    public LayerMask whatIsGround, WhatIsEnemy;

    //Attacking
    public float timeBetweenAttacks;
    public bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool enemyInSightRange, enemyInAttackRange;

    public float distance;
    public float nearestDistance = float.MaxValue;

    protected AnimationManager _animationManager;
    protected FindUnitsToAttack _findNearestObject;

    protected bool allNull;

    protected virtual void Start()
    {
        _animationManager = GetComponent<AnimationManager>();
        agent = GetComponent<NavMeshAgent>();
        _findNearestObject = FindObjectOfType<FindUnitsToAttack>();
    }

    protected void FindNearestEnemy(List<GameObject> listOfEnemies, float dist, float nearestDistance)
    {
        allNull = listOfEnemies.All(item => item == null);

        if (allNull)
        {
            return;
        }

        // Filter out null elements from the list
        listOfEnemies = listOfEnemies.Where(enemy => enemy != null).ToList();

        for (int i = 0; i < listOfEnemies.Count; ++i)
        {
            dist = Vector3.Distance(transform.position, listOfEnemies[i].transform.position);

            if (dist < nearestDistance)
            {
                enemy = listOfEnemies[i].transform;
                dist = nearestDistance;
            }
        }
    }

    protected void Idle()
    {
        _animationManager.IdleAnim();
    }

    protected void ChaseEnemy()
    {
        _animationManager.RunAnim();
        agent.SetDestination(enemy.position);
    }

    protected void AttackEnemy()
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

    protected void ResetAttack()
    {
        alreadyAttacked = false;
        _animationManager.IdleAnim();
    }
}
