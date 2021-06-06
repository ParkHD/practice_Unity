using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ITEM_TYPE
{
    None = -1,
    Ammo5_56mm,
    Ammo7_76mm,

}
public class Item
{
    [SerializeField] ITEM_TYPE name;
    [SerializeField] int count;
    public ITEM_TYPE Name => name;
    public int Count => count;
    public Item(Item item)
    {
        name = item.name;
        count = item.count;
    }
}
public class ItemObject : MonoBehaviour
{

}
