using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Use : MonoBehaviour
{
    public Image[] buttons;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        foreach(var button in buttons)
        {
            button.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (player.inventory.inv[0] != 0/*empty slot*/ && player.inventory.inv[0] != -1/*disabledslot*/) ;
    }
    public void ActivateButton(int type)
    {
        //change this objects sprite into the int "type" in the scriptable object, the index is litterally the same, 0 == 0, 1 == 1 and so on, ok???
    }
    public void Button()
    {
        if (player.inventory.inv[0] != 0/*empty slot*/ && player.inventory.inv[0] != -1/*disabledslot*/)
        {
            player.inventory.Interct(player.inventory.inv[0]);
        }
    }
}
