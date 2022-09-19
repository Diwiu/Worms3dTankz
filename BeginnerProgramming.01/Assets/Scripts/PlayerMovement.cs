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
    public void movement()
    {
       
        
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);


    }
}
