using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int id;
    GameManager gameManager;
    public int speed;
    private int spTurn;
    public int dashLenth;
    public float baseAttack;
    public int baseAttackSpeed;
    public int bAST;
    public float attackModifier;
    Player_FightSkript playerScript;
    public float dash;
    public Vector3 pos;
    private int where;
    public bool canMove;
    public bool isMoving;
    public bool hasMoved;
    public bool canAttack;
    public int enemyHP;
    public float distance;
    private GameObject player;
    EnemiesManager enemiesManager;
    public float X;
    public float Y;
    private void Start()
    {
        enemiesManager = GameObject.FindGameObjectWithTag("EnemiesManager").GetComponent<EnemiesManager>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_FightSkript>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        //speed = 3;
        //spTurn = Random.Range(0, speed);
        dashLenth = 1;
        baseAttack = 1;
        baseAttackSpeed = 1;
        bAST = 0;
        attackModifier = 1;
        enemyHP = Random.Range(2, 10);
        id = enemiesManager.enemies.Count - 1;
        canMove = false;
        isMoving = false;
        hasMoved = true;
        canAttack = false;
    }
    public void Update(){
        if(enemyHP <= 0){
            gameObject.SetActive(false);
            Destroy(gameObject);

        }
        distance = Vector2.Distance(transform.position, player.transform.position);
        if(gameManager.gameState == GameState.PlayerTurn && Input.GetKeyDown(KeyCode.Space) && distance == 1f){
            Takedamage(5);
        }
    }
    
    public void CanMove(Vector3 playerpos)
    {
        Vector3 diffPos = pos - playerpos;
        X = diffPos.x;
        Y = diffPos.y;
        //spTurn ++ ;
        if(Mathf.Abs(diffPos.x) + Mathf.Abs(diffPos.y) > 1 /*&& speed == spTurn*/) 
        {
            hasMoved = false;
            canMove = true;
            dash = 0;
            //spTurn = 0;
            List<int> list = new List<int>();
            if(diffPos.y > 0) list.Add(0);
            if(diffPos.y < 0) list.Add(1);
            if(diffPos.x > 0) list.Add(2);
            if(diffPos.x < 0) list.Add(3);
            where = list[Random.Range(0, list.Count)];//It just works
        }

    }
    public void Move()
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
        if(dashLenth == dash)
        {
            canMove = false;
            hasMoved = true;
        }
        transform.position = pos;
    }
    public void CanAttack(Vector3 playerPos){
        attackModifier = 1;
         Vector3 diffPos = pos - playerPos;
        X = diffPos.x;
        Y = diffPos.y;
        if(Mathf.Abs(diffPos.x) + Mathf.Abs(diffPos.y) == 1){
            canAttack = true;
            attackModifier /= playerScript.playerHP/100;
        }
    }
    public void Takedamage(int dmg){
        enemyHP -= dmg;
        gameManager.UpdateGameState(GameState.EnemyTurn);
    }
    void OnDestroy() {
        enemiesManager.DeleteInstance(id);
    }
    public void Attack(bool oppertunity = false){
        if(bAST == baseAttackSpeed || oppertunity){
            playerScript.Takedamage(baseAttack*Random.Range(attackModifier-0.1f, attackModifier+0.1f));
        }
        bAST++;
    }
}
