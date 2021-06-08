using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ITEM_TYPE
{
    None = -1,
    Ammo5_56mm,
    Ammo7_76mm,
}
[System.Serializable]
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
    [SerializeField] Item item;
    public void OnInteract()
    {
        Debug.Log(item.Name.ToString() + "È¹µæ");
        Destroy(gameObject);
    }
    public ITEM_TYPE GetName()
    {
        return item.Name;
    }
}
