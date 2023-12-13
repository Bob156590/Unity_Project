using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPacK : MonoBehaviour
{
    public float distance;
    MovementControls player;
    public Player_FightSkript playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_FightSkript>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementControls>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance == 0){
            playerScript.Heal(10);
            Destroy(gameObject);
        }
    }
}
