using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public int maxHealth = 20;

    public int currentHealth;
    public HealthBar healthBar;
    
    
   

	private void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}


	private void Update()
    {
	    if (currentHealth <= 0)
        {
            
            this.gameObject.SetActive(false);

        }
    }

    public void TakeDamage(int damage)
    {
	    Debug.Log("DamageTaken");
	    currentHealth -= damage;
	    
	    healthBar.SetHealth(currentHealth);
    }
	
}
