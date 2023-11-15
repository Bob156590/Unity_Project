using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{
    PlayerTurn,
    PlayerMove,
    EnemyTurn,
}
public class GameManager : MonoBehaviour
{
    public GameState gameState = GameState.PlayerTurn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per fram
    void Update()
    {
        
    }

    public void UpdateGameState(GameState newState){
        gameState = newState;
        if(newState == GameState.EnemyTurn)
        {
            
        }
    }
}
