using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    // Start is called before the first frame update
    public override void Start()
    {
        powerupsSpawner = GameObject.FindGameObjectWithTag("PUSpawner").GetComponent<PowerupsSpawner>();
        money = GameObject.FindGameObjectWithTag("Player").GetComponent<Money>();
        enemiesManager = GameObject.FindGameObjectWithTag("EnemiesManager").GetComponent<EnemiesManager>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<FightScript>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        speed = 1;
        spTurn = Random.Range(0, speed);
        dashLength = 1;
        baseAttack = 1;
        baseAttackSpeed = 1;
        bAST = 1;
        attackModifier = 1;
        enemyHP = Random.Range(2, 10);
        attackRange = 1;
        canMove = false;
        isMoving = false;
        hasMoved = true;
        canAttack = false;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
    public override void CanMove(Vector3 playerPos){
        base.CanMove(playerPos);
    }
    public override void Move(){
        base.Move();
    }
    public override void CanAttack(Vector3 playerPos){
        base.CanAttack(playerPos);
    }
    public override void Attack(bool oppertunity = false){
        base.Attack(oppertunity);
    }
    public override void Takedamage(int dmg){
        base.Takedamage(dmg);
    }

}
