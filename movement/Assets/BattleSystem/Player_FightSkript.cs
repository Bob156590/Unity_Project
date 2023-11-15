using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Player_FightSkript : MonoBehaviour
{
    public int playerHP;
    public int dmg;
    Enemy enemy;
    public float distance;
    GameObject enemies;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        playerHP = 100;
        dmg = 5;
        enemies = GameObject.FindGameObjectWithTag("Enemy");
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Takedamage(int dmg){
        playerHP -= dmg;
        gameManager.UpdateGameState(GameState.PlayerTurn);
    }
}
