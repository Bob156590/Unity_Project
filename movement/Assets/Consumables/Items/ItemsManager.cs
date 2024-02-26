using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class ItemsManager 
{
    public int[] inv = new int[9];
    private FightScript fPlayer;
    private PlayerMovement mPlayer;
    
    
    public void Initialize()
    {
        for (int i = 0; i < 9; i++){
            inv[i] = 0;//when difficulties aare added set some to -1
        }
        fPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<FightScript>();
        mPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public bool MoveToInv(int id)
    {
        for (int i = 0; i < 9; i++){
            if(inv[i] == 0 && inv[i] != -1)
            {    
                //Debug.Log($"Item id:{id}");
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
                fPlayer.Takedamage(50);
                return false;
            case 2:
                fPlayer.Heal(7);
                return true;
            case 3:
                mPlayer.maxMovement++;
                return true;
            default:
                return true;


        }
    }
    public void Interct(int index){
        if(UseItem(index)) RemoveItem(Array.IndexOf(inv, index));//remove the item in the onscreen inventory too

    }
    public void RemoveItem(int indx)
    {
        inv[indx] = 0;
    }
}
