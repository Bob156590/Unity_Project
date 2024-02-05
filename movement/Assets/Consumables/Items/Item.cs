using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    
    public Player player;
    public int type;
    
    // Start is called before the first frame update
    void Start()
    {
        type = 1;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    // Update is called once per frame
    void Update()
    {
        if(player.transform.position == transform.position)//when the player steps on the item move it to the inventory
        {
            if(player.inventory.MoveToInv(type)) Destroy(gameObject);
            //player.inventory.MoveToInv();//get me the index of the item here ye?
        }
    }
}