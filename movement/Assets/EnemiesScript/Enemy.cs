using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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
    public GameObject player;
    public EnemiesManager enemiesManager;
    public float X;
    public float Y;
    private void Start()
    {
        enemiesManager = GameObject.FindGameObjectWithTag("EnemiesManager").GetComponent<EnemiesManager>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_FightSkript>();
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
    public virtual void Update(){
        distance = Vector2.Distance(transform.position, player.transform.position);
        if(gameManager.gameState == GameState.PlayerTurn && Input.GetKeyDown(KeyCode.Space) && distance == 1f){
            Takedamage(5);
        }
        if(enemyHP <= 0){
            Destroy(gameObject);
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
        spTurn++;
        if(Mathf.Abs(diffPos.x) + Mathf.Abs(diffPos.y) > 1 && speed == spTurn) 
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
            bAST = 0;
        }
    }
    public virtual void Takedamage(int dmg){
        enemyHP -= dmg;
        gameManager.UpdateGameState(GameState.EnemyTurn);
    }
    public virtual void Attack(bool oppertunity = false){
        if(bAST == baseAttackSpeed || oppertunity){
            playerScript.Takedamage(baseAttack*Random.Range(attackModifier-0.1f, attackModifier+0.1f));
        }
        bAST++;
        canMove = false;
        hasMoved = true;
        canAttack = false;
    }
}
