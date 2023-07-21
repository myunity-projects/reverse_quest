using UnityEngine;

public class HumanUnits : BaseUnit
{
    protected override void Start()
    {
        base.Start();
        FindNearestEnemy(_findNearestObject.undeadWarriors, distance, nearestDistance);
    }

    private void Update()
    {
        FindNearestEnemy(_findNearestObject.undeadWarriors, distance, nearestDistance);

        //Check for sight and attack range
        enemyInSightRange = Physics.CheckSphere(transform.position, sightRange, WhatIsEnemy);
        enemyInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatIsEnemy);

        if (!enemyInSightRange && !enemyInAttackRange && !allNull)
        {
            Idle();
        }

        if (!enemyInSightRange && !enemyInAttackRange && allNull)
        {
            _animationManager.VictoryAnim();
        }

        if (enemyInSightRange && !enemyInAttackRange)
        {
            ChaseEnemy();
        }

        if (enemyInSightRange && enemyInAttackRange)
        {
            AttackEnemy();
        }
    }
}
