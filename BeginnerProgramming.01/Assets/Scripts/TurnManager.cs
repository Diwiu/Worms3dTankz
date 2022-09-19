using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    [SerializeField] private PlayerTurn playerOne;
    [SerializeField] private PlayerTurn playerTwo;
    [SerializeField] private float timeBetweenTurns;

    private PlayerTurn currentPlayer;
    public float turnDelay;
    private bool waitingForNextTurn = true;

    //public int currentPlayerIndex;
   // [SerializeField] private GameObject player1;
  //  private PlayerMovement player1Movement;

    private void Awake()
    {
        

            
            currentPlayer = playerOne;
            //playerOne.SwitchEnabled(false);
            //currentPlayerIndex = 1;
        

        //player1Movement = player1.GetComponent<PlayerMovement>().SetActive();
        

    }

    private void Update()
    {
        if (waitingForNextTurn)
        {
            turnDelay += Time.deltaTime;
            if (turnDelay >= timeBetweenTurns)
            {
                turnDelay = 0;
                waitingForNextTurn = true;
                ChangeTurn();
            }
        }
    }
    

    //public bool IsItPlayerTurn(int index)
    //{
        //return index == currentPlayerIndex;
    //}

    //public static TurnManager GetInstance()
    //{
      //  return instance;
    //}

    public void ChangeTurn()
    {
        Debug.Log("switch");
        if (currentPlayer == playerOne)
        {
            playerOne.SwitchEnabled(false);
            currentPlayer = playerTwo;
        }
        else if (currentPlayer == playerTwo)
        {
            playerTwo.SwitchEnabled(false);
            currentPlayer = playerOne;
        }

        currentPlayer.SwitchEnabled(true);

        //player1Movement.SetActive();


    }
    
}
