using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class ChargingEnemy : Enemy
{
    // Start is called before the first frame update
    public MovementControls playerMove;
    public bool charge;
    public bool push;
    void Start()
    {
        enemiesManager = GameObject.FindGameObjectWithTag("EnemiesManager").GetComponent<EnemiesManager>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_FightSkript>();
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementControls>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        speed = 1;
        spTurn = Random.Range(0, speed);
        dashLength = 1;
        baseAttack = 1;
        baseAttackSpeed = 1;
        bAST = 1;
        attackModifier = 1;
        enemyHP = Random.Range(2, 5);
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
    public override void CanMove(Vector3 playerPos)
    {
        Vector3 diffPos = pos - playerPos;
        X = diffPos.x;
        Y = diffPos.y;
        spTurn++;
        if(Mathf.Abs(diffPos.x) + Mathf.Abs(diffPos.y) > 1 && speed == spTurn && playerPos.x != transform.position.x && playerPos.y != transform.position.y) 
        {
            hasMoved = false;
            canMove = true;
            dash = 0;
            spTurn = 0;
            List<int> list = new List<int>();
            if(diffPos.y > 0) list.Add(0);
            if(diffPos.y < 0) list.Add(1);
            if(diffPos.x > 0) list.Add(2);
            if(diffPos.x < 0) list.Add(3);
            where = list[Random.Range(0, list.Count)];//It just works
        }
        else if(Mathf.Abs(diffPos.x) + Mathf.Abs(diffPos.y) == 1 && speed == spTurn) 
        {
            hasMoved = false;
            canMove = true;
            dash = 0;
            spTurn = 0;
            List<int> list = new List<int>();
            if(diffPos.y < 0) list.Add(0);
            if(diffPos.y > 0) list.Add(1);
            if(diffPos.x < 0) list.Add(2);
            if(diffPos.x > 0) list.Add(3);
            where = list[Random.Range(0, list.Count)];//It just works
        }
    }
    public override void Move()
    {
        base.Move();
    }

    public override void CanAttack(Vector3 playerPos){
        charge = false;
        Vector3 diffPos = pos - playerPos;
        spTurn = 0;
        distance = Vector2.Distance(transform.position, player.transform.position);
        attackModifier = 1;
        if(playerPos.x == transform.position.x && distance >= 2){
            dash = 0;
            canAttack = true;
            hasMoved = false;
            attackModifier /= playerScript.playerHP/100;
            if(diffPos.y > 0){
                where = 0;
                if(Mathf.Abs(diffPos.x) + Mathf.Abs(diffPos.y) > 2){
                    charge = true;
                }
            }
            else if(diffPos.y < 0){
                where = 1;
                if(Mathf.Abs(diffPos.x) + Mathf.Abs(diffPos.y) > 2){
                    charge = true;
                }
            }

        }
        else if(playerPos.y == transform.position.y && distance >= 2){
            dash = 0;
            canAttack = true;
            hasMoved = false;
            attackModifier /= playerScript.playerHP/100;
            if(diffPos.x > 0){
                where = 2;
                if(Mathf.Abs(diffPos.x) + Mathf.Abs(diffPos.y) > 2){
                    charge = true;
                }
            }
            else if(diffPos.x < 0){
                where = 3;
                if(Mathf.Abs(diffPos.x) + Mathf.Abs(diffPos.y) > 2){
                    charge = true;
                }
            }
        }
    }
    public override void Attack(bool oppertunity = false){
        if(charge){
            switch(where)
            {
                case 0:
                    pos.y -= 0.125f;
                    break;
                case 1:
                    pos.y += 0.125f;
                    break;
                case 2:
                    pos.x -= 0.125f;
                    break;
                case 3:
                    pos.x += 0.125f;
                    break;
            }
            dash += 0.0625f;
            if(dashLength == dash)
            {
                canAttack = false;
                canMove = false;
                hasMoved = true;
                push = true;
            }
            transform.position = pos;
        }
        else{
            switch(where)
            {
                case 0:
                    pos.y -= 0.0625f;
                    break;
                case 1:
                    pos.y += 0.0625f;
                    break;
                case 2:
                    pos.x -= 0.0625f;
                    break;
                case 3:
                    pos.x += 0.0625f;
                    break;
            }
            dash += 0.0625f;
            if(dashLength == dash)
            {
                canAttack = false;
                canMove = false;
                hasMoved = true;
                push = true;
            }
            transform.position = pos;
        }
        if(charge && Mathf.Abs(pos.x) + Mathf.Abs(pos.y) == 1){
            push = true;
        }
        if(push){
            switch(where){
                 case 0:
                    playerMove.Push(new Vector3(0, -0.0625f, 0));
                    push = false;
                    break;
                case 1:
                    playerMove.Push(new Vector3(0, +0.0625f, 0));
                    push = false;
                    break;
                case 2:
                    playerMove.Push(new Vector3(-0.0625f, 0, 0));
                    push = false;
                    break;
                case 3:
                    playerMove.Push(new Vector3(0.0625f, 0, 0));
                    push = false;
                    break;
            }
        }
    }

}
