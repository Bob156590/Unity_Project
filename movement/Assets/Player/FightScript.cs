using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightScript : Player
{
    public int overTimeEffect;
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
        if(gameManager.gameState == GameState.PlayerMove)
        {
            if(overTimeEffect > 0)
            {
                Takedamage2(10, overTimeEffect -= 1);
            }
        }
    }

    public void Heal(float hp){
        if(playerHP + hp <= 100)
        {
            healthBar.SetHealth(playerHP+hp);
            playerHP += hp;
        }
        else
        {
            healthBar.SetHealth(100);
        }
    }
    public void Takedamage(float dmg){
        playerHP -= dmg * physRes;
        healthBar.SetHealth(playerHP);
        gameManager.UpdateGameState(GameState.PlayerTurn);
    }
    public void Takedamage2(float dmg, int ote){
        Debug.Log($"stuff + {ote}");
        overTimeEffect = ote;
        playerHP -= dmg * physRes;
        healthBar.SetHealth(playerHP);
    }
}
