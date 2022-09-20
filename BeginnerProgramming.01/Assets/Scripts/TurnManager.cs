using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    
    // make players visible in inspector
    private static TurnManager instance;
    [SerializeField] private List<PlayerTurn> playerTurns;
    [SerializeField] private float timeBetweenTurns;
    public GameObject[] players;

    private int playerIndex;
    public float turnDelay;
    

    //public int currentPlayerIndex;
   // [SerializeField] private GameObject player1;
  //  private PlayerMovement player1Movement;

    private void Awake()
    {

            
            //playerIndex = playerTurns.Count - 1;
            //ChangeTurn();
            
            //playerOne.SwitchEnabled(false);
            //currentPlayerIndex = 1;
        

        //player1Movement = player1.GetComponent<PlayerMovement>().SetActive();
        

    }

    private void Update()
    {
       
            turnDelay += Time.deltaTime;
            if (turnDelay >= timeBetweenTurns)
            {
                ChangeTurn();
            }
        
    }
    

   
// Changes turn
    public void ChangeTurn()
    {
        // resets timer after turn is changed
        turnDelay = 0;
        
        if (playerIndex == playerTurns.Count - 1)
        {
            playerIndex = 0;
            //If player is dead, change turn
            if (players[playerIndex].GetComponent<PlayerManager>().health <= 0)
            {
                ChangeTurn();
            }
        }
        else
        {
            playerIndex++;
            //If player is dead, change turn
            if (players[playerIndex].GetComponent<PlayerManager>().health <= 0)
            {
                ChangeTurn();
            }
        }
        
        for(int i = 0; i < playerTurns.Count; i++)
        {
            var player = playerTurns[i];
            if(i == playerIndex)
            {
                player.SwitchEnabled(true);
            }
            else
            {
                player.SwitchEnabled(false);
            }
        }
    }
    
}
