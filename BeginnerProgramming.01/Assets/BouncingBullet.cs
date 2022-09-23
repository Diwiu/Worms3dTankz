using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBullet : MonoBehaviour
{
    
    
    private int damageCount = 5;
    
    
    void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Collision");
            collision.transform.GetComponent<PlayerManager>().TakeDamage(damageCount);
            GameObject.Find("TurnManager").GetComponent<TurnManager>().ChangeTurn();
            
        }
        
    }
}
