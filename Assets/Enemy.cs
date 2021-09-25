using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: make enemy into an interface not a class

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // TODO: add hurt animation here 

        if(currentHealth < 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("died");

        // TODO: add die animation here

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
