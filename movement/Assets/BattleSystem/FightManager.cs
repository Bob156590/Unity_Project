using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public int eHP = 3;
    public int pHP = 5;
    private GameObject enemy;
    private GameObject player;

    GameManager gameManager;
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(pHP == 0){
            Destroy(player);
        }
        if(eHP == 0){
            
            Destroy(enemy);
        }
    }

    public void PlayerTakeDamage(int amount){
        pHP -= amount;
        gameManager.UpdateGameState(GameState.PlayerTurn);
    }
    public void EnemyTakeDamage(int amount){
        eHP -= amount;
        gameManager.UpdateGameState(GameState.EnemyTurn);
    }
    public void Enemyopportunity(int amount){
        pHP -= amount;
    }
}
