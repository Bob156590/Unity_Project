using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_FightSkript : MonoBehaviour
{
    private GameObject player;
    GameManager gameManager;
    FightManager fightManager;
    public float distance;
    bool opportunity;
    private int enemyPos;
    EnemiesManager enemiesManager;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        fightManager = GameObject.FindGameObjectWithTag("FightManager").GetComponent<FightManager>();
        enemiesManager = GameObject.FindGameObjectWithTag("EnemiesManager").GetComponent<EnemiesManager>();
    }

    // Update is called once per frame
    void Update(){

    }
}
