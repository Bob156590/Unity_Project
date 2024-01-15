using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumales : Item
{
    public string type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseItem(ref Consumales item)
    {
        switch (item.type)
        {
            case "DebugItem01":
                playerScript.physRes = 0;
                break;
        }
    }
}
