using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TurnManager : MonoBehaviour
{
    
    // make players visible in inspector
    private static TurnManager instance;
    [SerializeField] private List<PlayerTurn> playerTurns;
    [SerializeField] private float timeBetweenTurns;
    public Turnstatus currentStatus;

    //Timer
    [SerializeField] private TextMeshProUGUI countdownText;
    public float turnDelay;
    
    public GameObject[] players;
    private int playerIndex;
    
    
  private void Awake()
    {
        currentStatus = Turnstatus.playerturn;
    }

    private void Update()
    {
        turnDelay -= Time.deltaTime;

        countdownText.text = turnDelay.ToString("##");
        if (turnDelay <= 0)
        {
            turnDelay = 0;
        }


        if (turnDelay <= timeBetweenTurns)
        {
            SetTurnStatus();
            SetTurnDelay();
        }

    }

    

   
// Changes turn
    public void ChangeTurn()
    {
        // resets timer after turn is changed
        
        if (playerIndex == playerTurns.Count - 1)
        {
            playerIndex = 0;
            //If player is dead, change turn
            if (players[playerIndex].GetComponent<PlayerManager>().currentHealth <= 0)
            {
                ChangeTurn();
            }
        }
        else
        {
            playerIndex++;
            //If player is dead, change turn
            if (players[playerIndex].GetComponent<PlayerManager>().currentHealth <= 0)
            {
                ChangeTurn();
            }
        }
    }

    public void SetTurnDelay()
    {
        if (currentStatus == Turnstatus.countdown)
        {
            turnDelay = 3;
            
        }
        else
        {
            turnDelay = 10;
        }
    }

    public void SetTurnStatus()
    {
        if (currentStatus == Turnstatus.countdown)
        {
            currentStatus = Turnstatus.playerturn;
            playerTurns[playerIndex].SwitchEnabled(true, true);
        }
        else
        {
            playerTurns[playerIndex].SwitchEnabled(false, false);
            ChangeTurn();
            playerTurns[playerIndex].SwitchEnabled(false, true);
            currentStatus = Turnstatus.countdown;
        }
    }
    
    
}
