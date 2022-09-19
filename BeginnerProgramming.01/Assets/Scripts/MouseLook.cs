using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public Transform body; // set here the player transform 
    float xRotation = 0f;
    public Vector2 turn;
    public float sensitivity = 5000;
    public Vector3 deltaMove;
    public float speed = 1;
    [SerializeField] private int playerIndex;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void mouse()
    {
        
        
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            turn.y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;



            xRotation -= turn.y;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);


            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            body.Rotate(Vector3.up * mouseX);
        
        
    }
}
