using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory
{
    public event System.Action<List<Item>> OnUpdateInven;

    List<Item> inven = new List<Item>();

    public void GetItem(Item item)
    {
        inven.Add(item);
        OnUpdateInven(inven);
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

    [SerializeField] GameObject invenUI;

    public Inventory inven;
    bool OnInven;
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
            if(OnInven)
            {
                invenUI.SetActive(true);
                inven.ShowInven();
                OnInven = false;
            }
            else
            {
                invenUI.SetActive(false);
                OnInven = true;
            }
        }
    }
}
