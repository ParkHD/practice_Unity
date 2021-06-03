using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : Singleton<InventoryUI>
{
    [SerializeField] InventorySlotUI itemSlot;
    [SerializeField] Text itemInfo;
    [SerializeField] Text itemName;
    [SerializeField] Transform slotParent;

    InventorySlotUI[] allSlots;

    private void OnEnable()
    {
        if(allSlots == null)
        {
            allSlots = slotParent.GetComponentsInChildren<InventorySlotUI>();
            PlayerStatus.Instance.inven.OnUpdateInven += OnUpdateInven;
            itemSlot.OnShowInfo += OnShowInfo;
            for(int i =0;i<allSlots.Length;i++)
            {
                allSlots[i].OnShowInfo += OnShowInfo;
            }
        }

        Cursor.lockState = CursorLockMode.None;
    }
    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void Clear()
    {
        for(int i = 0;i< allSlots.Length;i++)
        {
            allSlots[i].Clear();
        }
    }
    private void OnUpdateInven(List<Item> list)
    {
        Clear();
        for(int i = 0;i<list.Count;i++)
        {
            allSlots[i].SetUp(list[i]);
        }
    }

    private void OnShowInfo(Item item)
    {
        itemSlot.SetUp(item);
        itemName.text = item.name.ToString();
        itemInfo.text = item.itemExplain;
    }
}
