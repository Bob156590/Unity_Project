using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    public float runAway;
    // Start is called before the first frame update
    void Start()
    {
        enemiesManager = GameObject.FindGameObjectWithTag("EnemiesManager").GetComponent<EnemiesManager>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_FightSkript>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        speed = 1;
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
    public override void Update(){
        base.Update();
    }

    public override void CanMove(Vector3 playerPos)
    {
        Vector3 diffPos = pos - playerPos;
        X = diffPos.x;
        Y = diffPos.y;
        spTurn++;
        if(Mathf.Abs(diffPos.x) + Mathf.Abs(diffPos.y) < 6 && speed == spTurn) 
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
        else if(Mathf.Abs(diffPos.x) + Mathf.Abs(diffPos.y) > 7 && speed == spTurn){
            hasMoved = false;
            canMove = true;
            dash = 0;
            spTurn = 0;
            List<int> list = new List<int>();
            if(diffPos.y > 0) list.Add(0);
            if(diffPos.y < 0) list.Add(1);
            if(diffPos.x > 0) list.Add(2);
            if(diffPos.x < 0) list.Add(3);
            where = list[Random.Range(0, list.Count)];
        }
    }

    public override void Move()
    {
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
            canMove = false;
            hasMoved = true;
        }
        transform.position = pos;
    }

    public override void CanAttack(Vector3 playerPos){
        attackModifier = 1;
        Vector3 diffPos = pos - playerPos;
        X = diffPos.x;
        Y = diffPos.y;
        if(Mathf.Abs(diffPos.x) + Mathf.Abs(diffPos.y) == 6 || Mathf.Abs(diffPos.x) + Mathf.Abs(diffPos.y) == 7){
            spTurn = 0;
            canAttack = true;
            hasMoved = false;
            attackModifier /= playerScript.playerHP/100;
            bAST = 1;
        }
    }
    
    public override void Takedamage(int dmg){
        enemyHP -= dmg + 2;
        gameManager.UpdateGameState(GameState.EnemyTurn);
    }
    public override void Attack(bool oppertunity = false){
        if(bAST == baseAttackSpeed || oppertunity){
            playerScript.Takedamage(baseAttack*Random.Range(attackModifier-0.1f, attackModifier+0.1f));
        }
        bAST++;
        canMove = false;
        hasMoved = true;
        canAttack = false;
    }
}
