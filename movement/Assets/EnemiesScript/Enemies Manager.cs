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
    public GameObject mPrefab;
    public GameObject rPrefab;
    public GameObject cPrefab;
    private GameObject cEnemy;
    private GameObject mEnemy;
    private GameObject rEnemy;
    bool setupMove = true;
    
    // Start is called before the first frame update
    void Start()
    {
        cEnemy = GameObject.FindGameObjectWithTag("Charger");
        mEnemy = GameObject.FindGameObjectWithTag("MeleeEnemy");
        rEnemy = GameObject.FindGameObjectWithTag("RangedEnemy");
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        SpawnEnemy(3.5f, 0.5f, 2);
        //SpawnEnemy(Random.Range(-21, 20)+0.5f, Random.Range(-4, 3)+0.5f, 2);
        //SpawnEnemy(Random.Range(-21, 20)+0.5f, Random.Range(-4, 3)+0.5f, 1);
    }
    
        // Update is called once per frame
    void LateUpdate()
    {
        if(gameManager.gameState == GameState.EnemyTurn){
            if(setupMove) SetOppertunities();
            foreach(Enemy enemy in enemies)
            {
                if(enemy)
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
                mEnemy = Instantiate(mPrefab);
                mEnemy.GetComponent<MeleeEnemy>().pos = new Vector3(x, y, -1);
                enemies.Add(mEnemy.GetComponent<MeleeEnemy>());
                mEnemy.transform.position = new Vector3(x, y,-1);
                return;
            case 1:
                rEnemy = Instantiate(rPrefab);
                rEnemy.GetComponent<RangedEnemy>().pos = new Vector3(x, y, -1);
                enemies.Add(rEnemy.GetComponent<RangedEnemy>());
                rEnemy.transform.position = new Vector3(x, y,-1);
                return;
            case 2:
                cEnemy = Instantiate(cPrefab);
                cEnemy.GetComponent<ChargingEnemy>().pos = new Vector3(x, y, -1);
                enemies.Add(cEnemy.GetComponent<ChargingEnemy>());
                cEnemy.transform.position = new Vector3(x, y,-1);
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
}
