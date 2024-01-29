using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    
    public GameObject player;
    private PlayerMovement movement;
    public EnemiesManager enemiesManager;
    // Start is called before the first frame update
    void Start()
    {
        enemiesManager = GameObject.FindGameObjectWithTag("EnemiesManager").GetComponent<EnemiesManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(player.transform.position.y) >= 4.5){
            movement.GoBack();
        }
        if(Mathf.Abs(player.transform.position.x) >= 7.5){
            movement.GoBack();
        }
        foreach(Enemy i in enemiesManager.enemies){
            if(Mathf.Abs(i.transform.position.y) >= 4.5){
                i.GoBack();
            }
            if(Mathf.Abs(i.transform.position.x) >= 7.5){
                i.GoBack();
            }
            if(player.transform.position == i.transform.position){
                movement.GoBack();
            }
        }
    }
}
