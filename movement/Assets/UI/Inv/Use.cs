using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Use : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.inventory.inv[0] != 0/*empty slot*/ && player.inventory.inv[0] != -1/*disabledslot*/) ;
    }
    public void Buttn()
    {
        if (player.inventory.inv[0] != 0/*empty slot*/ && player.inventory.inv[0] != -1/*disabledslot*/) player.inventory.Interct(player.inventory.inv[0]);
    }
}
