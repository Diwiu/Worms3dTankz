using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    // get stuff from other scripts
    
    //private PlayerMovement playerMovement;
    private Cannon cannon;
    private MouseLook mouseLook;
    private Camera cam;
    private CharacterMovement _playerMovement;
    
    private float fireRate = 1f;
    private float nextFire = 0f;
    
    
    // enable / disable on inspector
    
    public bool isEnabled;
    [SerializeField] private Gun Gun;


    public void Awake()
    {
        Debug.Log("Im Awake: "+ isEnabled);
        cannon = GetComponentInChildren<Cannon>();
        mouseLook = GetComponentInChildren<MouseLook>();
        //playerMovement = GetComponent<PlayerMovement>();
        cam = GetComponentInChildren<Camera>();
        _playerMovement = GetComponent<CharacterMovement>();
    }

    private void Update()
    {
        if(isEnabled)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                cannon.Fire();
                
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Gun.Shooting();
            }
            
            if (Input.GetKeyDown(KeyCode.R) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Gun.Shooting();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _playerMovement.Jump();
            }
            //playerMovement.movement();
            mouseLook.mouse();
            _playerMovement.MovePlayer();

        }
        
        
    }


    
    
    public void SwitchEnabled(bool enableMovement, bool enableCamera)
    {
        isEnabled = enableMovement;
        cam.enabled = enableCamera;
        
    }
}
