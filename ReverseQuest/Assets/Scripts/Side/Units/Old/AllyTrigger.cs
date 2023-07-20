using UnityEngine;

public class AllyTrigger : MonoBehaviour
{
    AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.Find("SoundManager").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            audioManager.PlaySfx(AudioClipName.BattleStart);
            Ally.onAllyAttacked += other.GetComponent<Enemy>().GetDamage;
            ChildrenAttack();
        }

        else if (other.CompareTag("Tower"))
        {
            Ally.onAllyAttacked += other.GetComponent<Tower>().GetDamage;
            ChildrenAttack();
        }
    }

    private void ChildrenAttack()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Ally>().Attack();
        }
    }
}
