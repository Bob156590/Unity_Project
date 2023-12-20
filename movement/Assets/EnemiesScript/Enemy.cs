using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PowerupsSpawner powerupsSpawner;
    public Money money;
    public GameManager gameManager;
    public int speed;
    public int spTurn; //Wait before moving
    public int dashLength; //Max dashlength
    public float baseAttack; //How had it can attcl
    public int baseAttackSpeed; //How fast it can attack
    public int bAST;
    public int attackRange; //How far away it can attack from
    public float attackModifier; //Modific dmg positively and negatively
    public Player_FightSkript playerScript;
    public float dash; //
    public Vector3 pos;
    public int where;
    public bool canMove;
    public bool isMoving;
    public bool hasMoved;
    public bool canAttack;
    public int enemyHP;
    public float distance;
    protected GameObject player;
    public EnemiesManager enemiesManager;
    public float X;
    public float Y;
    public Vector3 check;
    public Vector3 lastPos;
    public virtual void Start()
    {
        powerupsSpawner = GameObject.FindGameObjectWithTag("PUSpawner").GetComponent<PowerupsSpawner>();
        money = GameObject.FindGameObjectWithTag("Player").GetComponent<Money>();
        enemiesManager = GameObject.FindGameObjectWithTag("EnemiesManager").GetComponent<EnemiesManager>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_FightSkript>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        speed = 1;
        spTurn = Random.Range(0, speed);
        dashLength = 1;
        baseAttack = Random.Range(1, 10);
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
    public virtual void Update(){
        check = transform.position - player.transform.position;
        if((gameManager.gameState == GameState.PlayerTurn || gameManager.gameState == GameState.PlayerMove) && Input.GetKeyDown(KeyCode.RightArrow) && check.x == 1 && Mathf.Abs(check.x) + Mathf.Abs(check.y) == 1){
            Takedamage(5);
        }
        if((gameManager.gameState == GameState.PlayerTurn || gameManager.gameState == GameState.PlayerMove) && Input.GetKeyDown(KeyCode.LeftArrow) && check.x == -1 && Mathf.Abs(check.x) + Mathf.Abs(check.y) == 1){
            Takedamage(5);
        }
        if((gameManager.gameState == GameState.PlayerTurn || gameManager.gameState == GameState.PlayerMove) && Input.GetKeyDown(KeyCode.UpArrow) && check.y == 1 && Mathf.Abs(check.x) + Mathf.Abs(check.y) == 1){
            Takedamage(5);
        }
        if((gameManager.gameState == GameState.PlayerTurn || gameManager.gameState == GameState.PlayerMove) && Input.GetKeyDown(KeyCode.DownArrow) && check.y == -1 && Mathf.Abs(check.x) + Mathf.Abs(check.y) == 1){
            Takedamage(5);
        }
        if(enemyHP <= 0){
            Destroy(gameObject);
            money.coins += 15;
            powerupsSpawner.Spawn(transform.position);
            enemiesManager.enemies.Remove(this);
        }
    }
    /// <summary>
    /// Checks if the enemy can move or not. if yes, it decides which direction to moves.
    /// </summary>
    /// <param name="playerPos">Player position</param>
    public virtual void CanMove(Vector3 playerPos)
    {
        Vector3 diffPos = pos - playerPos;
        X = diffPos.x;
        Y = diffPos.y;
        if(Mathf.Abs(diffPos.x) + Mathf.Abs(diffPos.y) > 1) 
        {
            hasMoved = false;
            canMove = true;
            dash = 0;
            List<int> list = new List<int>();
            if(diffPos.y > 0) list.Add(0);
            if(diffPos.y < 0) list.Add(1);
            if(diffPos.x > 0) list.Add(2);
            if(diffPos.x < 0) list.Add(3);
            where = list[Random.Range(0, list.Count)];//It just works
            lastPos = transform.position;
        }
    }
    public virtual void Move()
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
    public virtual void CanAttack(Vector3 playerPos){
        attackModifier = 1;
        Vector3 diffPos = pos - playerPos;
        X = diffPos.x;
        Y = diffPos.y;
        if(Mathf.Abs(diffPos.x) + Mathf.Abs(diffPos.y) == 1){
            canAttack = true;
            hasMoved = false;
            attackModifier /= playerScript.playerHP/100;
        }
    }
    public virtual void Takedamage(int dmg){
        enemyHP -= dmg;
        gameManager.UpdateGameState(GameState.EnemyTurn);
    }
    public virtual void Attack(bool oppertunity = false){
        if(bAST == baseAttackSpeed){
            playerScript.Takedamage(baseAttack*Random.Range(attackModifier-0.1f, attackModifier+0.1f));
        }
        canMove = false;
        hasMoved = true;
        canAttack = false;
    }
    public virtual void GoBack(){
        transform.position = lastPos;
        gameManager.UpdateGameState(GameState.PlayerTurn);
    }
}
