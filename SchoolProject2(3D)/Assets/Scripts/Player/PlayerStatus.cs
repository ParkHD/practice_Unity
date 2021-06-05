using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory
{
    public event System.Action<Item[]> OnUpdateInven;

    Item[] inven = new Item[15];

    public void GetItem(Item item)
    {
        for(int i = 0;i<inven.Length;i++)
        {
            if(inven[i] == null)
            {
                inven[i] = item;
                break;
            }
        }
        OnUpdateInven(inven);
    }
    public void ShowInven()
    {
        
    }
    public void MoveItem(int originIndex, int targetIndex)
    {
        Item temp = inven[originIndex];
        inven[originIndex] = inven[targetIndex];
        inven[targetIndex] = temp;
        OnUpdateInven(inven);
    }
    public void DropItem(int index, Transform pos)
    {
        ItemObject dropitem = ItemManager.Instance.MakeItem(inven[index].name);
        dropitem.transform.position = pos.position + pos.forward;
        dropitem.GetComponent<Rigidbody>().AddForce(pos.forward * 6f, ForceMode.Impulse);

        inven[index] = null;
        
        OnUpdateInven(inven);
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
                OnInven = false;
            }
            else
            {
                invenUI.SetActive(false);
                OnInven = true;
            }
        }
    }
    public void DropItem(int index)
    {

    }
}
