using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapChanger : MonoBehaviour
{
    int level;
    public List<GameObject> cameras;
    public EnemiesManager enemiesManager;
    public  GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemiesManager = GameObject.FindGameObjectWithTag("EnemiesManager").GetComponent<EnemiesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V)){
            cameras[level].SetActive(false);
            cameras[level+1].SetActive(true);
            level++;
            player.transform.position = new Vector3(.5f, 9.5f, -1);
        }

        if(enemiesManager.enemies.Count == 0){
        }
    }
}
