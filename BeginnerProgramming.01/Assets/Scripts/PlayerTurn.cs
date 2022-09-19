using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Cannon cannon;
    [SerializeField] private MouseLook mouseLook;
    [SerializeField] private Camera cam;
    public bool isEnabled;


    private void Update()
    {
        if(isEnabled == true)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                cannon.Fire();
                Debug.Log("emmy");
            }
            playerMovement.movement();
            mouseLook.mouse();
        }
        
        
    }


    
    
    public void SwitchEnabled(bool weirdabled)
    {
        isEnabled = weirdabled;
        cam.enabled = weirdabled;
        //playerMovement.enabled = weirdabled;
        //cannon.enabled = weirdabled;
        //mouseLook.enabled = weirdabled;
        //cam.enabled = weirdabled;
    }
}
