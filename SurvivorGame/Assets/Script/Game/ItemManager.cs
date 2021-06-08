using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    [SerializeField] ItemObject[] itemArray;

    public ItemObject MakeItem(ITEM_TYPE itemName)
    {
        for(int i = 0;i<itemArray.Length;i++)
        {
            if(itemArray[i].GetName() == itemName)
            {
                return Instantiate(itemArray[i]);
            }
        }
        return null;
    }
}
