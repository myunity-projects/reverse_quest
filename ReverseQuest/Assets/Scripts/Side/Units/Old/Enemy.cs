using System;
using UnityEngine;

public class Enemy : Unit
{
    public static Action<int> onEnemyAttacked;

    [SerializeField] private int _damage;

    public override void Attack()
    {
        if (onEnemyAttacked != null)
        {
            onEnemyAttacked.GetInvocationList()[0].DynamicInvoke(_damage);
        }

        else
        {
            return;
        }

        transform.GetComponent<Animator>().SetBool("isRunning", false);
        transform.GetComponent<Animator>().Play("Attack");
        base.Attack();
    }

    protected override void OnDestroy()
    {
        Ally.onAllyAttacked -= GetDamage;
    }
}
