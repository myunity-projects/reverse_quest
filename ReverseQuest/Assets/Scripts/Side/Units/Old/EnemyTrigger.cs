using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ally"))
        {
            Enemy.onEnemyAttacked += other.GetComponent<Ally>().GetDamage;
            ChildrenAttack();
        }
    }

    private void ChildrenAttack()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Enemy>().Attack();
        }
    }
}