using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    None,
    Bullet_7_62,
    Bullet_5_56,
    Gem,
}

public class ItemManager : MonoBehaviour
{
    private static ItemManager instance;
    public static ItemManager Instance => instance;

    [SerializeField] ItemObject[] itemArray;
    private void Awake()
    {
        instance = this;    
    }

    public ItemObject MakeItem(ItemType itemName)
    {
        for(int i = 0;i<itemArray.Length;i++)
        {
            if(itemArray[i].GetType() == itemName)
            {
                return Instantiate(itemArray[i]);
            }
        }
        return null;
    }
}
