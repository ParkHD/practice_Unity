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
public class Item : ScriptableObject
{
    [SerializeField] string itemName;
    [SerializeField] Sprite image;
    [SerializeField] int count;
    [SerializeField] string info;

    protected string itemType;
    public string ItemType => itemType;

    public string Name => itemName;
    public int Count => count;
    public Sprite ItemImage => image;
    public string Info => info;
    public Item(Item item)
    {
        itemName = item.itemName;
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
        PlayerState.Instance.GetItem(item);
        Destroy(gameObject);
    }
    public string GetName()
    {
        return item.Name;
    }
    public new string GetType()
    {
        return item.ItemType;
    }
}
