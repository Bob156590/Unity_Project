using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatSwitch : MonoBehaviour
{
    private MovementControls player;
    public GameManager gameManager;
    public Player_FightSkript player_FightSkript;
    public GameObject everything;
    public TMP_Text text;
    private bool button = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementControls>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        player_FightSkript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_FightSkript>();
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.gameState == GameState.PlayerTurn && Input.GetKeyDown(KeyCode.Tab) && button){
            everything.SetActive(false);
            text.enabled = true;
            text.text = $"Health: {player_FightSkript.playerHP}\nDmg: {player_FightSkript.dmg}\nSpeed: {player.maxMovement}";
            button = false;
        }
        else if(gameManager.gameState == GameState.PlayerTurn && Input.GetKeyDown(KeyCode.Tab) && !button){
            everything.SetActive(true);
            text.enabled = false;
            button = true;
        }
    }
}
