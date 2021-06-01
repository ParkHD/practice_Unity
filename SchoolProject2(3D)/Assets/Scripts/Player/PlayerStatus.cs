using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory
{
    List<Item> inven = new List<Item>();

    public void GetItem(Item item)
    {
        inven.Add(item);
    }
    public void ShowInven()
    {
        Debug.Log("Inventory");
        for(int i = 0;i<inven.Count;i++)
        {
            Debug.Log(string.Format("{0}. {1}", i, inven[i].name));
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
    private void Update()
    {
        ShowInven();
    }
    public void ShowInven()
    {
        if(Input.GetKeyUp(KeyCode.I))
        {
            inven.ShowInven();
        }
    }
}
