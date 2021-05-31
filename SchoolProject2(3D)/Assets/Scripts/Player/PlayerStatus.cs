using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory
{
    List<Item> inven = new List<Item>();

    public void GetItem(Item item)
    {
        inven.Add(item);
        ShowInven();
    }
    public void ShowInven()
    {
        foreach(Item item in inven) 
        {
            Debug.Log(item.name);
        }
    }
}

public class PlayerStatus : MonoBehaviour
{
    private static PlayerStatus instance;
    public static PlayerStatus Instance => instance;

    public Inventory inven;

    private void Awake()
    {
        instance = this;
        inven = new Inventory();
    }
}
