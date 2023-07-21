using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

        healthBar = GetComponentInChildren<Canvas>().GetComponentInChildren<HealthBar>();
        animationManager = GetComponent<AnimationManager>();

        healthBar.SetMaxHealth(maxHealth);

        isAlive = true;
    }

    public void RecieveDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Current Health = " + currentHealth);
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0 && !gameObject.name.Contains("Tower"))
        {
            isAlive = false;
            animationManager.DeathAnim();
            Destroy(gameObject);
        }
        else if(currentHealth <= 0 && gameObject.name.Contains("Tower"))
        {
            isAlive = false;
            Destroy(gameObject);
        }
    }
}
