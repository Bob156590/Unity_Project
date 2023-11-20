using UnityEngine;

public class Player_FightSkript : MonoBehaviour
{
    public float playerHP;
    public float distance;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        playerHP = 100;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHP <= 0){
            
        }
    }

    public void Takedamage(float dmg){
        playerHP -= dmg;
        gameManager.UpdateGameState(GameState.PlayerTurn);
    }
}
