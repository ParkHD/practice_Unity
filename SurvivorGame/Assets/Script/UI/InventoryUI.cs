using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class InventoryUI : Singleton<InventoryUI>
{
    InventorySlot[] slots;

    [SerializeField] Image selectedItemImage;
    [SerializeField] Text selectedItemName;
    [SerializeField] Text selectedItemInfo;
    [SerializeField] InventorySlot dummySlot;

    private void Awake()
    {
        base.Awake();
        slots = GetComponentsInChildren<InventorySlot>();
        PlayerState.Instance.Inven.UpdateInven += UpdateInven;

        for(int i = 0;i<slots.Length;i++)
        {
            slots[i].ShowInfo += ShowInfo;
            slots[i].ClearInfo += ClearInfo;
            slots[i].DragBegin += DragBegin;
            slots[i].Dragging += Dragging;
            slots[i].DragEnd += DragEnd;
        }
    }
    private void OnEnable()
    {
        ClearInfo();
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
    private void DragBegin(Item item)
    {
        dummySlot.SetUp(item);
        dummySlot.gameObject.SetActive(true);
    }
    private void Dragging()
    {
        dummySlot.transform.position = Input.mousePosition;
    }
    private void DragEnd()
    {
        dummySlot.gameObject.SetActive(false);
        int targetIndex = InventorySlot.targetIndex;
        int originIndex = InventorySlot.originIndex;
        Debug.Log("Origin : " + originIndex); 
        Debug.Log("target : " + targetIndex); 
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
