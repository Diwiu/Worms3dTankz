using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public int maxHealth = 20;

    public int currentHealth;
    public HealthBar healthBar;
    private TurnManager _turnManager;
    
    
   

	private void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		_turnManager = FindObjectOfType<TurnManager>();
	}


	private void Update()
    {
	    if (currentHealth <= 0)
        {
            
            this.gameObject.SetActive(false);
			_turnManager.playerDied();
        }
    }

    public void TakeDamage(int damage)
    {
	    Debug.Log("DamageTaken");
	    currentHealth -= damage;
	    
	    healthBar.SetHealth(currentHealth);
    }

    
    
}
