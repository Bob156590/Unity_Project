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
    public GameObject prefab;
    public GameObject enemySpawn;
    bool setupMove = true;
    
    // Start is called before the first frame update
    void Start()
    {
        enemySpawn = GameObject.FindGameObjectWithTag("Enemy");
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        SpawnEnemy(3.5f, -3.5f);
        SpawnEnemy(Random.Range(-21, 20)+0.5f, Random.Range(-4, 3)+0.5f);
        SpawnEnemy(Random.Range(-21, 20)+0.5f, Random.Range(-4, 3)+0.5f);
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

    private void SpawnEnemy(float x, float y)
    {
        enemySpawn = Instantiate(prefab);
        //enemySpawn enemies[enemies.Count - 1];
        enemySpawn.GetComponent<Enemy>().pos = new Vector3(x, y, 0);
        enemies.Add(enemySpawn.GetComponent<Enemy>());
        enemySpawn.transform.position = new Vector3(x, y,0);
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
