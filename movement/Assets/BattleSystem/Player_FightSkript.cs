using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_FightSkript : MonoBehaviour
{
    public float playerHP;
    public float distance;
    public float physRes;//Physical resistance
    public float dmg;
    HealthBar healthBar;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        physRes = 1;
        dmg = 10;
        playerHP = 100;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        healthBar.MaxHealth(playerHP);
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
