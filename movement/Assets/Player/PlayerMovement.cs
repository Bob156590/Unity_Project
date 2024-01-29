using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Player
{

    [SerializeField]
    public LayerMask stopWall;
    public float speed = 1f;
    int distanceMoved = 0;
    public int moved = 0;
    public bool move;
    public int maxMovement = 1;
    Vector3 velocity = new Vector3();
    Vector3 lastPos;
    
    // Start is called before the first frame update

    // Update is called once per frame
    private void Update() {
        if((gameManager.gameState == GameState.PlayerTurn || gameManager.gameState == GameState.PlayerMove) && Input.GetKeyDown(KeyCode.Space)){
            gameManager.UpdateGameState(GameState.EnemyTurn);
            lastPos = transform.position;
        }
        if(gameManager.gameState == GameState.PlayerTurn)
        {
            move = true;
            /*Process playerturn*/
            if(Input.GetKeyDown(KeyCode.W) ){
                gameManager.UpdateGameState(GameState.PlayerMove);
                velocity = new Vector3(0, speed);
            }
            if(Input.GetKeyDown(KeyCode.S) ){
                gameManager.UpdateGameState(GameState.PlayerMove);

                velocity = new Vector3(0, -speed);
            }
            if(Input.GetKeyDown(KeyCode.A) ){
                gameManager.UpdateGameState(GameState.PlayerMove);

                velocity = new Vector3(-speed, 0);;
            }
            if(Input.GetKeyDown(KeyCode.D)){
                gameManager.UpdateGameState(GameState.PlayerMove);

                velocity = new Vector3(speed, 0);
            }
            lastPos = transform.position;
        }
        else if(gameManager.gameState== GameState.PlayerMove){
            if(moved != maxMovement && move){
                if(distanceMoved == 16){
                    distanceMoved = 0;
                    moved++;
                }
                else{
                    transform.position += velocity * 1/16f;
                    distanceMoved++;
                }
            }
            if(moved == maxMovement && enemiesManager.enemies.Count == 0){
                move = false;
                moved -= moved;
                gameManager.UpdateGameState(GameState.PlayerTurn);
            }
            else if(moved == maxMovement && enemiesManager.enemies.Count != 0){
                move = false;
                moved -= moved;
            }
            if(distanceMoved == 0 && moved != 0){
                gameManager.UpdateGameState(GameState.PlayerTurn);
            }
        }
    }
    public void Push(Vector3 pos){
        while (distanceMoved != 16){
            transform.position += pos;
            distanceMoved++;
        }
        distanceMoved = 0;
    }
    public void GoBack(){
        //FightScript.Takedamage(5);
        transform.position = lastPos;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        //playerScript.Takedamage(5);
        transform.position = lastPos;
    }
}
