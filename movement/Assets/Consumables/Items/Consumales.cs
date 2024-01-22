using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumales : Item
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public Consumales(string type)
    {
        switch (type)
        {
            case "DebugItem01":
                this.type = type;
                uses = 100;
                inInv = true;
                break;
            
        }
        this.Spawn();
    }
    
    public override void UseItem(string item)
    {
        switch (item)
        {
            case "DebugItem01":
                playerScript.physRes = 0;
                break;
        }
    }
}