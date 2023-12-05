using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    GameManager gameManager;
    Transform player;
    public List<Enemy> enemies = new List<Enemy>();
    bool enemiesMoved;
    public GameObject mprefab;
    public GameObject rprefab;
    public GameObject mEnemy;
    public GameObject rEnemy;
    bool setupMove = true;
    
    // Start is called before the first frame update
    void Start()
    {
        mEnemy = GameObject.FindGameObjectWithTag("Enemy");
        rEnemy = GameObject.FindGameObjectWithTag("RangedEnemy");
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        SpawnEnemy(1.5f, 0.5f, 1);
        //SpawnEnemy(Random.Range(-21, 20)+0.5f, Random.Range(-4, 3)+0.5f,0);
        //SpawnEnemy(Random.Range(-21, 20)+0.5f, Random.Range(-4, 3)+0.5f);
    }
    
        // Update is called once per frame
    void Update()
    {
        if(gameManager.gameState == GameState.EnemyTurn){
            if(setupMove) SetOppertunities();
            foreach(Enemy enemy in enemies)
            {
                if(enemy.canMove && !enemy.canAttack)
                {
                    enemy.Move();
                }
                else if(enemy.canAttack){
                    enemy.Attack();
                }
            }
            SetState();
        }
    }

    private void SpawnEnemy(float x, float y, int type)
    {
        switch(type)
        {
            case 0:
                mEnemy = Instantiate(mprefab);
                //mEnemy enemies[enemies.Count - 1];
                mEnemy.GetComponent<Enemy>().pos = new Vector3(x, y, -1);
                enemies.Add(mEnemy.GetComponent<Enemy>());
                mEnemy.transform.position = new Vector3(x, y,-1);
                return;
            case 1:
                rEnemy = Instantiate(rprefab);
                //mEnemy enemies[enemies.Count - 1];
                rEnemy.GetComponent<RangedEnemy>().pos = new Vector3(x, y, -1);
                enemies.Add(rEnemy.GetComponent<RangedEnemy>());
                rEnemy.transform.position = new Vector3(x, y,-1);
                return;
            
        }
        
    }

    public void SetState()
    {
        enemiesMoved = true;
        foreach (Enemy enemy in enemies){
            if(!enemy.hasMoved) 
            {
                enemiesMoved = false;
                break;
            }
        }
        if(enemiesMoved){
            gameManager.UpdateGameState(GameState.PlayerTurn);
            setupMove = true;
            foreach (Enemy i in enemies)
            {
                i.hasMoved = false;
            }
        } 
    }

    public void SetOppertunities()
    {
        foreach(Enemy enemy in enemies)
        {
            enemy.CanMove(player.position);
            enemy.CanAttack(player.position);
        }
        setupMove = false;
    }
    public void DeleteInstance(int id)
    {
        enemies.RemoveAt(id);
        for(int i = id; i < enemies.Count; i++)
        {
            enemies[i].id = -1;
        }
    }
}
