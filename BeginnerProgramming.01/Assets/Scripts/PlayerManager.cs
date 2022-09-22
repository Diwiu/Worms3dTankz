using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int health = 20;
    // [SerializeField] private Gun Gun;
	//public PlayerMovement pm;
	//public Cannon cannon;
	//public MouseLook ml;
	//public int myIndex;

	
	
	
    private void Update()
    {
	    
	    // if (Input.GetKeyDown(KeyCode.R))
	    // {
		   //  Gun.Shooting();
	    // }
        if (health <= 0)
        {
            //this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            //this.gameObject.GetComponent<BoxCollider>().enabled = false;
            //this.gameObject.GetComponent<CharacterController>().enabled = false;
            this.gameObject.SetActive(false);

        }
		//if (GameObject.Find("TurnManager").GetComponent<TurnManager>().currentPlayerIndex == myIndex)
        
    }

	
}
