using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_FightSkript : MonoBehaviour
{
    public float playerHP;
    public float distance;
    public float dmg;
    HealthBar healthBar;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
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

    public void Takedamage(float dmg){
        playerHP -= dmg;
        healthBar.SetHealth(playerHP);
        gameManager.UpdateGameState(GameState.PlayerTurn);
    }
}
