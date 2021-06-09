using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InventorySlotUI : MonoBehaviour
{
    Item item;

    [SerializeField] Image selectedImage;
    [SerializeField] Image itemImage;
    [SerializeField] Text itemCount;

    public event Action<Item> ShowInfo;
    public event Action ClearInfo;
    public void OnCursorEnter()
    {
        selectedImage.enabled = true;
        ShowInfo(item);
    }
    public void OnCursorExit()
    {
        selectedImage.enabled = false;
        ClearInfo();
    }
    
    public void SetUp(Item item)
    {
        this.item = item;
        if(item == null)
        {
            Clear();
            return;
        }
        itemImage.enabled = true;

        itemImage.sprite = item.ItemImage;
        itemCount.text = item.Count > 1?item.Count.ToString() : "";
    }
    public void Clear()
    {
        itemImage.enabled = false;
        itemCount.text = "";
    }
}
