using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public ItemType name;
    public int count;
    public Sprite itemImage;
    public string itemExplain;
    public Item(Item copy)
    {
        name = copy.name;
        count = copy.count;
    }
   
}
public class ItemObject : MonoBehaviour, Iinteraction
{
    [SerializeField] Item item;

    public void OnInteract()
    {
        PlayerStatus.Instance.inven.GetItem(item);
        Destroy(gameObject);
    }
    public string GetName()
    {
        return item.name.ToString();
    }
    public new ItemType GetType()
    {
        return item.name;
    }
}
