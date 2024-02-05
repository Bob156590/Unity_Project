using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class ItemsManager 
{
    public int[] inv = new int[9];
    private FightScript player;

    public void Initialize()
    {
        for (int i = 0; i < 9; i++){
            inv[i] = 0;//when difficulties aare added set some to -1
        }
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FightScript>();
    }

    public bool MoveToInv(int id)
    {
        for (int i = 0; i < 9; i++){
            if(inv[i] == 0 && inv[i] != -1)
            {
                inv[i] = id;
                return true;
            } 
        }
        return false;
    }
    public void SpawnItem(int id, UnityEngine.Vector3 pos)
    {
        //create an objet here at the pos
    }
    public bool UseItem(int id)
    {
        switch(id){
            case 1:
                player.Takedamage(50);
                return false;
            default:
                return true;


        }
    }
    public void Interct(int index){
        if(UseItem(inv[index])) RemoveItem(index);//remove the item in the onscreen inventory too

    }
    public void RemoveItem(int indx)
    {
        inv[indx] = 0;
    }
}
