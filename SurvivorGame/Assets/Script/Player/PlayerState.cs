using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Inventory
{
    Item[] itemArray;

    public event Action<Item[]> UpdateInven;
    public Inventory()
    {
        itemArray = new Item[15];
    }
    public void ShowInven()
    {
        UIManager.Instance.ShowInven();
        UpdateInven?.Invoke(itemArray); 
    }
    public void GetItem(Item item)
    {
        for(int i = 0;i<itemArray.Length;i++)
        {
            if(itemArray[i] == null)
            {
                itemArray[i] = item;
                UpdateInven?.Invoke(itemArray);
                break;
            }
        }
    }
    public void MoveItem(int originIndex, int targetIndex)
    {
        Item temp = itemArray[originIndex];
        itemArray[originIndex] = itemArray[targetIndex];
        itemArray[targetIndex] = temp;

        UpdateInven(itemArray);
    }
}

public class PlayerState : Singleton<PlayerState>
{
    Inventory inven;
    public Inventory Inven => inven;
    private void Awake()
    {
        base.Awake();
        inven = new Inventory();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ShowInven();
        }
    }
    private void ShowInven()
    {
        inven.ShowInven();
    }
    public void GetItem(Item item)
    {
        inven.GetItem(item);
    }

}