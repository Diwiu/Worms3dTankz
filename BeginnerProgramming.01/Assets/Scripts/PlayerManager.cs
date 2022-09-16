using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int health = 20;

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
