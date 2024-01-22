using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public Player_FightSkript playerScript;
    public GameObject player;
    public string type;
    
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_FightSkript>();
        player = GameObject.FindWithTag("Player");
    }

    public void Spawn(Vector3 pos){

    }

    public abstract void UseItem(string item);

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position == transform.position){

        }
    }
}
