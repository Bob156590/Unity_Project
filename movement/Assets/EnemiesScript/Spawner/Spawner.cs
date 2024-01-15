using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public EnemiesManager enemiesManager;
    // Start is called before the first frame update
    void Start()
    {
        enemiesManager = GameObject.FindGameObjectWithTag("EnemiesManager").GetComponent<EnemiesManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesManager.enemies.Count == 0){
            for(int i = 0; i < Random.Range(1,3); i++){
                enemiesManager.SpawnEnemy(Random.Range(-8, 7)+0.5f, Random.Range(-4, 3)+0.5f, 2);
            }
            for(int i = 0; i < Random.Range(0,2); i++){
                enemiesManager.SpawnEnemy(Random.Range(-8, 7)+0.5f, Random.Range(-4, 3)+0.5f, 2);
            }
            for(int i = 0; i < Random.Range(0,1); i++){
                enemiesManager.SpawnEnemy(Random.Range(-8, 7)+0.5f, Random.Range(-4, 3)+0.5f, 2);
            }
        }
    }
}
