using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int health = 20;
	//public PlayerMovement pm;
	//public Cannon cannon;
	//public MouseLook ml;
	//public int myIndex;

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
		//if (GameObject.Find("TurnManager").GetComponent<TurnManager>().currentPlayerIndex == myIndex)
        
    }

	
}
