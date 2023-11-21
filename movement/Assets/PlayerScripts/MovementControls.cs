using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MovementControls : MonoBehaviour
{
    [SerializeField]
    public LayerMask stopWall;
    private float time = 0.5f;
    private float timer = 0f;
    public float speed = 1f;
    int distanceMoved = 0;
    public int moved = 0;
    private int maxMovement = 1;
    Vector3 velocity = new Vector3();
    GameManager gameManager;
    Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    private void Update() {
        if(gameManager.gameState == GameState.PlayerTurn)
        {
            /*Process playerturn*/
            if (Input.GetKeyDown(KeyCode.W) ){
                gameManager.UpdateGameState(GameState.PlayerMove);
                velocity = new Vector3(0, speed);
            }
            if (Input.GetKeyDown(KeyCode.S) ){
                gameManager.UpdateGameState(GameState.PlayerMove);

                velocity = new Vector3(0, -speed);
            }
            if (Input.GetKeyDown(KeyCode.A) ){
                gameManager.UpdateGameState(GameState.PlayerMove);

                velocity = new Vector3(-speed, 0);
            }
            if (Input.GetKeyDown(KeyCode.D)){
                gameManager.UpdateGameState(GameState.PlayerMove);

                velocity = new Vector3(speed, 0);
            }
            lastPos = transform.position;
        }
        else if(gameManager.gameState== GameState.PlayerMove){
            if (moved != maxMovement){
                if(distanceMoved == 16){
                    distanceMoved = 0;
                    moved++;
                }
                else{
                    transform.position += velocity * 1/16f;
                    distanceMoved++;
                }
            }
            if (moved == maxMovement){
                gameManager.UpdateGameState(GameState.EnemyTurn);
                moved -= moved;
            }
            if(distanceMoved == 0 && moved != 0){
                gameManager.UpdateGameState(GameState.PlayerTurn);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        transform.position = lastPos;
    }

}