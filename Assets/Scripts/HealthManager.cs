using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int health;
    private int currentHealth;
    public UICounter UICounter;

    void Start()
    {
        currentHealth = health;
        UICounter.UpdateText(currentHealth, "Health");
    }

    
    void Update()
    {
        if (currentHealth <= 0)
        {
            KillPlayer();

        }
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
        
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        UICounter.UpdateText(currentHealth, "Health");
    }

    private void KillPlayer()
    {
        Destroy(gameObject);

    }

}
