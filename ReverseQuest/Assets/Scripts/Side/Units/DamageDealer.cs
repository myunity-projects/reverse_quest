using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private string[] tags = { "Undead", "Human" };

    public float damage = 1;

    private void OnTriggerEnter(Collider collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();

        if (collision.gameObject.CompareTag(tags[0]))
        {
            if (health != null)
            {
                health.RecieveDamage(damage);
            }
        }
    }
}
