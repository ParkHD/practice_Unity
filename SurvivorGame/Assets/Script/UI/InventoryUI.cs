using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class InventoryUI : Singleton<InventoryUI>
{
    InventorySlotUI[] slots;

    [SerializeField] Image selectedItemImage;
    [SerializeField] Text selectedItemName;
    [SerializeField] Text selectedItemInfo;

    private void Awake()
    {
        base.Awake();
        slots = GetComponentsInChildren<InventorySlotUI>();
        PlayerState.Instance.Inven.UpdateInven += UpdateInven;

        for(int i = 0;i<slots.Length;i++)
        {
            slots[i].ShowInfo += ShowInfo;
            slots[i].ClearInfo += ClearInfo;
        }
    }
    private void Start()
    {
        ClearInven();
    }
    private void UpdateInven(Item[] itemArray)
    {
        for(int i = 0; i < slots.Length;i++)
        {
            slots[i].SetUp(itemArray[i]);
        }
    }
    private void ShowInfo(Item item)
    {
        if(item == null)
        {
            return;
        }
        selectedItemImage.enabled = true;
        selectedItemImage.sprite = item.ItemImage;
        selectedItemInfo.text = item.Info;
        selectedItemName.text = item.Name.ToString();
    }
    private void ClearInfo()
    {
        selectedItemImage.enabled = false;
        selectedItemInfo.text = "";
        selectedItemName.text = "";
    }
    private void ClearInven()
    {
        ClearInfo();
        for (int i = 0;i<slots.Length;i++)
        {
            slots[i].Clear();
        }
    }
}
