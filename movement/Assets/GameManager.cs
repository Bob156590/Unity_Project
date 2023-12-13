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
    int[,] map;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per fram
    void Update()
    {
        
    }

    public void MapCreator(int floorLvl, int exp){
        map = new int[10,10];
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                map[i,j] = 1;
            }
        }
        for (int i = 0; i < 10; i++)
        {
            map[0,i] = 0;
            map[i,0] = 0;
            map[9,i] = 0;
            map[i,9] = 0;
        }
        if(floorLvl > 10)
        {
            map[Random.Range(1,8),Random.Range(1,8)] = 0;
            map[Random.Range(1,8),Random.Range(1,8)] = 0;
        }
        
    }

    public void UpdateGameState(GameState newState){
        gameState = newState;
        if(newState == GameState.EnemyTurn)
        {
            
        }
    }
}
