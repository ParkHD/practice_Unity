using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] Sprite image;
    [SerializeField] int count;
    [SerializeField] string info;
    public ITEM_TYPE Name => name;
    public int Count => count;
    public Sprite ItemImage => image;
    public string Info => info;
    public Item(Item item)
    {
        name = item.name;
        count = item.count;
        image = item.image;
        info = item.info;
    }
}
public class ItemObject : MonoBehaviour
{
    [SerializeField] Item item;
    public void OnInteract()
    {
        Debug.Log(item.Name.ToString() + "È¹µæ");
        PlayerState.Instance.GetItem(item);
        Destroy(gameObject);
    }
    public ITEM_TYPE GetName()
    {
        return item.Name;
    }
}
