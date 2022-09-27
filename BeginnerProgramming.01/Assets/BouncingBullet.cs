using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBullet : MonoBehaviour
{
    
    
    public int damageCount = 1;
    
    
    void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Collision");
            collision.transform.GetComponent<PlayerManager>().TakeDamage(damageCount);
            
            
        }
        
    }
}
