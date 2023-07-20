using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;

    public float currentHealth;

    public bool isAlive;

    private HealthBar healthBar;
    private AnimationManager animationManager;

    void Start()
    {
        currentHealth = maxHealth;

        healthBar = GetComponentInChildren<HealthBar>();
        animationManager = GetComponent<AnimationManager>();

        healthBar.SetMaxHealth(maxHealth);

        isAlive = true;
    }

    public void RecieveDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            isAlive = false;
            animationManager.DeathAnim();
        }
    }
}
