using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float life = 3;
    private int damageCount = 5;

    
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, life);
    }

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
