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

    private int playerIndex;
    public float turnDelay;
    

    //public int currentPlayerIndex;
   // [SerializeField] private GameObject player1;
  //  private PlayerMovement player1Movement;

    private void Awake()
    {

            
            playerIndex = playerTurns.Count - 1;
            ChangeTurn();
            
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
    

   

    public void ChangeTurn()
    {
        turnDelay = 0;
        // switches player and disables last player
        if (playerIndex == playerTurns.Count - 1)
        {
            playerIndex = 0;
        }
        else
        {
            playerIndex++;
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



        //currentPlayer.SwitchEnabled(false);
        //if (currentplayer == playerone)
        //{
        //    debug.log("setting1");
        //    currentplayer = playertwo;
        //}
        //else if (currentplayer == playertwo)
        //{
        //    debug.log("setting2");
        //    currentplayer = playerone;
        //}

        //currentPlayer.SwitchEnabled(true);

        //player1Movement.SetActive();


    }
    
}
