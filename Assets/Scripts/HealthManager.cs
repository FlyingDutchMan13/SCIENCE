using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int health;
    private int currentHealth;
    void Start()
    {
        currentHealth = health;

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

    }

    private void KillPlayer()
    {
        Destroy(gameObject);

    }

}
