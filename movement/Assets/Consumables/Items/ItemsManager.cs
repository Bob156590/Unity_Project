using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class ItemsManager 
{

    private List<int> items;
    public List<int> inv;
    public Item item=new();
    public void MoveToInv(int indx)
    {
        SpawnItem(items[indx]);
        RemoveItem(indx, false);
    }
    public void SpawnItem(int id)
    {
        inv.Add(id);
        //create an objet here in inv
    }
    public void SpawnItem(int id, UnityEngine.Vector3 pos)
    {
        items.Add(id);
        //create an objet here at the pos
    }
    public bool UseItem(int id)
    {
        switch(id){
            case 0:
                return false;
            default:
                return true;


        }
    }
    public void Interct(int index){
        if(UseItem(inv[index])) RemoveItem(index);//remove the item in the onscreen inventory too

    }
    public void RemoveItem(int indx, bool inInv = true)
    {
        if(inInv) 
        {
            inv.RemoveAt(indx);
            return;
        }
        items.RemoveAt(indx);

    }
}
