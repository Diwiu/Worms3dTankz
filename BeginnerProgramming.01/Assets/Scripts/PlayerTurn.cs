using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    // get stuff from other scripts
    
    private PlayerMovement playerMovement;
    private Cannon cannon;
    private MouseLook mouseLook;
    private Camera cam;
    // enable / disable on inspector
    
    public bool isEnabled;


    public void Awake()
    {
        Debug.Log("Im Awake: "+ isEnabled);
        cannon = GetComponentInChildren<Cannon>();
        mouseLook = GetComponentInChildren<MouseLook>();
        playerMovement = GetComponent<PlayerMovement>();
        cam = GetComponentInChildren<Camera>();

    }

    private void Update()
    {
        if(isEnabled == true)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                cannon.Fire();
                
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
