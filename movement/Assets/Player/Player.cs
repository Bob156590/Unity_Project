using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public ItemsManager inventory = new();
    public float playerHP;
    public float distance;
    public float physRes;//Physical resistance
    public float dmg;
    public HealthBar healthBar;
    public GameManager gameManager;
    public EnemiesManager enemiesManager;
    // Start is called before the first frame update
    public virtual void Start()
    {
        inventory.Initialize();
        physRes = 1;
        dmg = 10;
        playerHP = 100;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        enemiesManager = GameObject.FindGameObjectWithTag("EnemiesManager").GetComponent<EnemiesManager>();
        healthBar.MaxHealth(playerHP);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
