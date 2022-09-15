using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int playerIndex;
    
    public CharacterController controller;
    public float speed = 12f;
    public Camera cam;

    // Update is called once per frame
    void LateUpdate()
    {
        if (TurnManager.GetInstance().IsItPlayerTurn(playerIndex))
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            cam.enabled = true;
            controller.enabled = true;
        }
        else
        {
            cam.enabled = false;
            controller.enabled = false;
        }
          
        
    }
}
