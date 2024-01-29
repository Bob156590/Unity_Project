using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightScript : Player
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
 void Update()
    {
        if(playerHP <= 0){
            SceneManager.LoadScene("GameOver");
        }
    }

    public void Heal(float hp){
        if(playerHP + hp <= 100){
            healthBar.SetHealth(playerHP+hp);
            playerHP += hp;
        }
        else{
            healthBar.SetHealth(100);
        }
    }
    public void Takedamage(float dmg){
        playerHP -= dmg * physRes;
        healthBar.SetHealth(playerHP);
        gameManager.UpdateGameState(GameState.PlayerTurn);
    }
}
