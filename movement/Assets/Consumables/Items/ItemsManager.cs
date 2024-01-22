using System.Collections;
using System.Collections.Generic;

public class ItemsManager 
{

    private List<Item> items;

    public void UseItem(int index){
        items[index].UseItem(items[index].type);
        if(items[index].uses == 0)items.RemoveAt(index);
        else items[index].uses--;

    }
}
